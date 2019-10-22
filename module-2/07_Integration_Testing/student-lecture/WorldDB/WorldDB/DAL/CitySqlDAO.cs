using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public int AddCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // TODO: Select @@Identity is one way to get back the id of the newly added city (Identity field)
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO city VALUES (@name, @countrycode, @district, @population); Select @@Identity;", conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    // Select @@Identity will return the last Id added.
                    // TODO: Use ExecuteScalar to get back a single value (one row, one column) from a query.
                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    // TODO: THis is another way to get the newly added ID, but it really does not scale
                    //cmd = new SqlCommand("SELECT MAX(id) FROM city;", conn);
                    //int id = Convert.ToInt32(cmd.ExecuteScalar());
                    return id;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error saving city.");
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public IList<City> GetAllCities()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection to SQL Server
                    connection.Open();

                    // Create a Command object to execute query to get all cities
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city ORDER BY population DESC;", connection);

                    // Execute the command to get a result set, read by the SqlReader
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through the rows, and print data to the screen
                    List<City> cities = new List<City>();

                    while (reader.Read())
                    {
                        cities.Add(RowToObject(reader));
                    }
                    return cities;

                }
            }
            catch (SqlException exception)
            {
                // TODO: We should log here....
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> cities = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // TODO: Here is an example of a parameterized query. @cc is the query parameter, and its value is supplied by the C# variable countryCode
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE countryCode = @cc ORDER BY population DESC;", conn);
                    cmd.Parameters.AddWithValue("@cc", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City city = RowToObject(reader);
                        cities.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading cities by country.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return cities;
        }

        private City RowToObject(SqlDataReader reader)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(reader["id"]);
            city.Name = Convert.ToString(reader["name"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);

            return city;
        }
    }
}
