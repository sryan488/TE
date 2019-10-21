using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using WorldDB.DAL;
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
            string connectionString = configuration.GetConnectionString("World");

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
    }
}
