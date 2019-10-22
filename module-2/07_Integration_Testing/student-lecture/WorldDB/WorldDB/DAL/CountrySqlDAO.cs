using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based country dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CountrySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<Country> GetCountries()
        {
            // Declare the output variable
            List<Country> countries = new List<Country>();

            try
            {
                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a command to send to the database
                    // TODO: Note the Country queries all do a LEFT JOIN to get the capital name, if it exists.
                    SqlCommand cmd = new SqlCommand("SELECT co.*, ci.name capitalname FROM country co LEFT JOIN city ci ON co.capital = ci.id;", conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read each row
                    while (reader.Read())
                    {
                        Country ctry = RowToObject(reader);
                        countries.Add(ctry);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the output
            return countries;
        }

        private Country RowToObject(SqlDataReader reader)
        {
            Country ctry = new Country();

            ctry.Code = Convert.ToString(reader["code"]);
            ctry.Name = Convert.ToString(reader["name"]);
            ctry.Continent = Convert.ToString(reader["continent"]);
            ctry.Region = Convert.ToString(reader["region"]);
            ctry.SurfaceArea = Convert.ToDouble(reader["surfacearea"]);
            ctry.GovernmentForm = Convert.ToString(reader["governmentform"]);


            // TODO: These are NULLable columns. We need to check for NULL value before converting
            // One way: ** if (reader.IsDBNull(reader.GetOrdinal("capital"))) **
            // Below is a way I like better. CHeck the Type of the column. NULL is type DBNull
            ctry.CapitalId = reader["capital"] is DBNull ? null : (int?)reader["capital"];
            ctry.HeadOfState = reader["headofstate"] is DBNull ? "" : (string)reader["headofstate"];
            ctry.IndependenceYear = reader["indepyear"] is DBNull ? null : (short?)reader["indepyear"];
            ctry.Population = reader["population"] is DBNull ? null : (int?)reader["population"];
            ctry.LifeExpectancy = reader["lifeexpectancy"] is DBNull ? null : (float?)reader["lifeexpectancy"];
            ctry.GNP = reader["gnp"] is DBNull ? null : (decimal?)reader["gnp"];
            ctry.GNPOld = reader["gnpold"] is DBNull ? null : (decimal?)reader["gnpold"];

            // TODO: CapitalName is the field we get from the left join. This is the aliased column name (see the queries).
            ctry.CapitalName = reader["capitalname"] is DBNull ? "" : (string)reader["capitalname"];

            return ctry;
        }

        public IList<Country> GetCountries(string continent)
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                                                                                // column    // param name  
                    SqlCommand cmd = new SqlCommand("SELECT co.*, ci.name capitalname FROM country co LEFT JOIN city ci ON co.capital = ci.id WHERE co.continent = @continent;", conn);
                                               // param name    // param value
                    cmd.Parameters.AddWithValue("@continent", continent);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Country ctry = RowToObject(reader);
                        countries.Add(ctry);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading countries by continent.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return countries;
        }

        public Country GetCountryByCode(string countryCode)
        {
            Country country = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // column    // param name  
                    SqlCommand cmd = new SqlCommand("SELECT co.*, ci.name capitalname FROM country co LEFT JOIN city ci ON co.capital = ci.id WHERE co.code = @countryCode;", conn);
                    // param name    // param value
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        country = RowToObject(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading countries by continent.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return country;
        }
    }
}
