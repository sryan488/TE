using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.DAL
{
    public class RecipeSqlDAO : IRecipeDAO
    {
        /******
            NOTE: There is no "ingredient" DAO.  There is really no need to read/write ingredients
            alone, only within the context of a recipe.  So all the loading/saving is done here, for both tables.
        *********/
        private readonly string connectionString;

        public RecipeSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves a new recipe into the database.  
        /// </summary>
        /// <param name="recipe">The recipe (including an Ingredients list) to Save</param>
        public int CreateRecipe(Recipe recipe)
        {
            /***
             * Since a Recipe has multiple Ingredients data in additoin to Recipe data, CreateRecipe needs
             * to do multiple inserts into the DB. We make the save a single "unit of work" by enclosing
             * it within a *Transaction*
             * ***/
            SqlTransaction transaction = null;
            try
            {
                /***
                 * We'll use a Transaction to make sure that no partial saves occur.
                 ***/
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //TODO: Finish this query
                    conn.Open();

                    // Start a transaction
                    transaction = conn.BeginTransaction();

                    /***
                     * The Insert SQL also does a "Select @@Identity" at the end, so that we
                     * we can get the id of the newly inserted row
                     * ***/
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine,
                            PrepTime, CookTime, Serves) 
                            VALUES (@Name, @CreatedById, @Description, @Steps, @Meal, @Cuisine,
                            @PrepTime, @CookTime, @Serves); Select @@Identity;", conn);
                    cmd.Parameters.AddWithValue("@Name", recipe.Name);
                    cmd.Parameters.AddWithValue("@CreatedById", recipe.CreatedById);
                    cmd.Parameters.AddWithValue("@Description", recipe.Description);
                    cmd.Parameters.AddWithValue("@Steps", recipe.Steps);
                    cmd.Parameters.AddWithValue("@Meal", recipe.Meal);
                    cmd.Parameters.AddWithValue("@Cuisine", recipe.Cuisine);
                    cmd.Parameters.AddWithValue("@PrepTime", recipe.PrepTime);
                    cmd.Parameters.AddWithValue("@CookTime", recipe.CookTime);
                    cmd.Parameters.AddWithValue("@Serves", recipe.Serves);
                    cmd.Transaction = transaction;

                    // ExecuteScalar allows us to get the ID back.
                    int recipeId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Loop through each Ingredient and write each one to the DB
                    foreach (Ingredient ing in recipe.Ingredients)
                    {
                        SqlCommand ingCmd = new SqlCommand(
                            @"Insert Into Ingredient (RecipeId, Name, Quantity, Unit) 
                            VALUES(@RecipeId, @Name, @Quantity, @Unit);", conn);
                        // The @Recipe parameter establishes the foreign key from Ingredient to Recipe
                        ingCmd.Parameters.AddWithValue("@RecipeId", recipeId);
                        ingCmd.Parameters.AddWithValue("@Name", ing.Name);
                        ingCmd.Parameters.AddWithValue("@Quantity", ing.Quantity);
                        ingCmd.Parameters.AddWithValue("@Unit", ing.Unit);

                        /*** The following line "enlists" the Insert command into the same transaction that
                         * was used to save the Recipe
                         * ***/
                        ingCmd.Transaction = transaction;

                        // Execute the Insert of an Ingredient
                        ingCmd.ExecuteNonQuery();
                    }

                    // commit the transaction
                    transaction.Commit();
                    return recipeId;
                }
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
        }

        /// <summary>
        /// Gets a recipe from the database. Since we are reading only ONE recipe, all the 
        /// ingredients for that recipe will be included in the Recipe.Ingredients list.
        /// </summary>
        /// <param name="id">The Id of the Recipe to read.</param>
        /// <returns>A complete Recipe object (with Ingredients). NULL if the Id does not exist.</returns>
        public Recipe GetRecipeById(int id)
        {
            Recipe recipe = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    /***
                     * Notice the SQL below has TWO statements. The first reads the one Recipe by ID. The 
                     * second statement reads all the Ingredients associated with that Recipe Id.
                     * ***/
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT * FROM Recipe WHERE Id = @Id;
                          Select * from Ingredient WHERE RecipeId = @Id", 
                        conn);
                    // Even though @Id is used twice in the Query above, it is only bound once.
                    cmd.Parameters.AddWithValue("@Id", id);

                    // Execute the Query
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Get the Recipe
                    if (reader.Read())  // THere will be zero or one
                    {
                        // Create the recipe object
                        recipe = RowToRecipe(reader);
                    }
                    else
                    {
                        // Not found - return NULL
                        return recipe;
                    }

                    /***
                     * Get the ingredients. reader.NextResult moves us to the second rowset returned 
                     * from our query (the ingredients)
                     * ***/
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            /***
                             * Use RowToIngredient to create an Ingredient object and
                             * then add it to the recipe's Ingredients list.
                             * ***/
                            recipe.Ingredients.Add(RowToIngredient(reader));
                        }
                    }
                }
                return recipe;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // The list of recipes DOES NOT include Ingredients
        /// <summary>
        /// Gets a list of recipes from the database that match a cuisine. Since we are reading 
        /// MULTIPLE recipes, all the ingredient lists for those recipes will be included EMPTY.
        /// This is because we are typically just listing recipe information, not ingredient details.
        /// </summary>
        /// <param name="cuisine">Cuisine to match Recipes. If empty, all recipes will be returned.</param>
        /// <returns>A list of Recipe objects, none of which has Ingredients</returns>
        public IList<Recipe> GetRecipes(string cuisine)
        {
            List<Recipe> list = new List<Recipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Create the *LIKE* filter
                    string cuisineFilter = $"%{cuisine}%";
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Recipe Where Cuisine like @cuisine", conn);
                    cmd.Parameters.AddWithValue("@cuisine", cuisineFilter);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // NOTE we call only RowToRecipe, not RowToIngredient
                        list.Add(RowToRecipe(reader));
                    }
                }

                return list;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Converts a Reader row to a Recipe object
        /// </summary>
        /// <param name="row">A row from SqlDataReader</param>
        /// <returns>A Recipe object</returns>
        private Recipe RowToRecipe(SqlDataReader row)
        {
            return new Recipe()
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = Convert.ToString(row["Name"]),
                CreatedById = Convert.ToInt32(row["CreatedById"]),
                Description = Convert.ToString(row["Description"]),
                Steps = Convert.ToString(row["Steps"]),
                Meal = Convert.ToString(row["Meal"]),
                Cuisine = Convert.ToString(row["Cuisine"]),
                ImageFile = Convert.ToString(row["ImageFile"]),
                PrepTime = Convert.ToInt32(row["PrepTime"]),
                CookTime = Convert.ToInt32(row["CookTime"]),
                Serves = Convert.ToInt32(row["Serves"]),
            };
        }

        /// <summary>
        /// Converts a Reader row to an Ingredient object
        /// </summary>
        /// <param name="row">A SqlDataReader row</param>
        /// <returns>An Ingredient object</returns>
        private Ingredient RowToIngredient(SqlDataReader row)
        {
            return new Ingredient()
            {
                Id = Convert.ToInt32(row["Id"]),
                RecipeId = Convert.ToInt32(row["RecipeId"]),
                Name = Convert.ToString(row["Name"]),
                Quantity = Convert.ToDouble(row["Quantity"]),
                Unit = Convert.ToString(row["Unit"]),
            };
        }


        /// <summary>
        /// A hard-coded list of valid Cuisines.  This could be replaced by a table in future iterations.
        /// </summary>
        /// <returns>A list of valid Cuisines</returns>
        public IList<string> GetCuisines()
        {
            return new List<string>()
            {
                "American",
                "Chinese",
                "Indian",
                "Italian",
                "Thai"
            };
        }

        /// <summary>
        /// A hard-coded list of valid Meal Types.  This could be replaced by a table in future iterations.
        /// </summary>
        /// <returns>A list of valid Meal Types</returns>
        public IList<string> GetMealTypes()
        {
            return new List<string>()
            {
                "Breakfast",
                "Lunch",
                "Dinner",
                "Snack",
                "Drink"
            };
        }

        /// <summary>
        /// A hard-coded list of valid Units of Measure.  This could be replaced by a table in future iterations.
        /// </summary>
        /// <returns>A list of valid Units of Measure</returns>
        public IList<string> GetUnits()
        {
            return new List<string>()
            {
                "tsp",
                "tbsp",
                "cups",
                "ounces",
                "pounds"
            };
        }
    }
}
