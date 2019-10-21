using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        public CitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddCity(City city)
        {
            throw new NotImplementedException();
        }

        public List<City> GetAllCities()
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

        public List<City> GetCitiesForCountryCode(string countryCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection to SQL Server
                    connection.Open();

                    // Create a Command object to execute query to get all cities
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE countrycode = @cc ORDER BY population DESC;", connection);
                    cmd.Parameters.AddWithValue("@cc", countryCode);

                    // Execute the command to get a result set, read by the SqlReader
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through the rows, and print data to the screen
                    List<City> cities = new List<City>();

                    while (reader.Read())
                    {
                        City city = RowToObject(reader);
                        cities.Add(city);
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

        private City RowToObject(SqlDataReader reader)
        {
            City city = new City();
            city.Id = Convert.ToInt32(reader["id"]);
            city.Name = Convert.ToString(reader["NAME"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);
            return city;

        }
    }
}
