using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using WorldDB.DAL;
using WorldDB.Views;

namespace WorldDB
{
    /***
     * NOTE: This program shows a number of features of C#, and the Client Data Library and DAO's in 
     * particular.  These features are strewn about the classes in this program...but I marked them
     * all with TODO's.  So turn on you Task List (in VS, View --> Task List) to see a short description.
     * Click on each task to go to the code.
     ***/
    //https://www.tanksthatgetaround.com/funny-city-names/


    class Program
    {
        static void Main(string[] args)
        {
            // TODO: This is how we load a configuration file and get the connection string
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("World");

            // TODO: This gets a custom value from the Config file (Section = DAO, Key = UseFileDAO
            bool useFileDAO = configuration.GetSection("DAO").GetValue<bool>("UseFileDAO", false);

            // TODO: Here, the Main method creates instances of DAOs which will be "injected" into the menu (CLI).
            ICityDAO cityDAO;
            ICountryDAO countryDAO;
            ILanguageDAO languageDAO;
            if (useFileDAO)
            {
                // TODO: This is a COMPLETELY different set of DAOs which implement the SAME interfaces
                cityDAO = new CityFileDAO(@"..\..\..\City_Data.txt");
                countryDAO = new CountryFileDAO(@"..\..\..\Country_Data.txt");
                languageDAO = new LanguageFileDAO(@"..\..\..\Language_Data.txt");
            }
            else
            {
                cityDAO = new CitySqlDAO(connectionString);
                countryDAO = new CountrySqlDAO(connectionString);
                languageDAO = new LanguageSqlDAO(connectionString);
            }

            // TODO: Here, we create the menu, and "inject" the DAOs we want to use
            WorldDBMenu menu = new WorldDBMenu(cityDAO, countryDAO, languageDAO);
            menu.Run();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }
    }
}
