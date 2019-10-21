using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using WorldDB.DAL;
using WorldDB.Models;
using WorldDB.Views;

namespace WorldDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code reads the connection string from appsettings.json
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            // Get the connection string for the World database
            string connectionString = configuration.GetConnectionString("World");

            CitySqlDAO cityDAO = new CitySqlDAO(connectionString);

            List<City> cities = cityDAO.GetAllCities();

            foreach (City city in cities)
            {
                Console.WriteLine($"{city.Id,5} {city.Name,-40} {city.Population,12:N0} ");
            }
            Console.ReadLine();

            cities = cityDAO.GetCitiesForCountryCode("GBR");

            foreach (City city in cities)
            {
                Console.WriteLine($"{city.Id,5} {city.Name,-40} {city.Population,12:N0} ");
            }

            
            
            // GetAllCities(connectionString);

            // GetCitiesForCountry(connectionString, "USA");

            Console.ReadLine();
            return;

            // TODO: Create a City Model class

            // TODO: Create a City SQL DAO Class (GetCities, GetCitiesByCountryCode)

            // TODO: List the cities of the world

            // TODO: List the cities in a Country (code)

            // TODO: Add a City to the US






            // TODO: Create instances of DAOs to pass into the menus



            // TODO: Create a WorldDBMenu and Run it
            WorldDBMenu menu = new WorldDBMenu();
            menu.Run();

            // Say goodbye to the user...
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }

        private static void GetAllCities(string connectionString)
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
                    City city = new City();
                    city.Id = Convert.ToInt32(reader["id"]);
                    city.Name = Convert.ToString(reader["NAME"]);
                    city.CountryCode = Convert.ToString(reader["countrycode"]);
                    city.District = Convert.ToString(reader["district"]);
                    city.Population = Convert.ToInt32(reader["population"]);
                    cities.Add(city);
                }

                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Id,5} {city.Name,-40} {city.Population,12:N0} ");
                }


            }
        }
        private static void GetCitiesForCountry(string connectionString, string countryCode)
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
                    City city = new City();
                    city.Id = Convert.ToInt32(reader["id"]);
                    city.Name = Convert.ToString(reader["NAME"]);
                    city.CountryCode = Convert.ToString(reader["countrycode"]);
                    city.District = Convert.ToString(reader["district"]);
                    city.Population = Convert.ToInt32(reader["population"]);
                    cities.Add(city);
                }

                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Id,5} {city.Name,-40} {city.Population,12:N0} ");
                }


            }
        }
    }
}
