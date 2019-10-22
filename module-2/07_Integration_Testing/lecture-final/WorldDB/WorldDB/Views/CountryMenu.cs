using WorldDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.DAL;

namespace WorldDB.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class CountryMenu : WorldDBMenu
    {
        private Country country;

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public CountryMenu(Country country, ICityDAO cityDAO, ICountryDAO countryDAO, ILanguageDAO languageDAO) : 
            base(cityDAO, countryDAO, languageDAO)
        {
            // Save the country (which will be used for all country queries
            this.country = country;
        }

        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", $"List Cities in {country.Name}");
            this.menuOptions.Add("2", $"List Languages in {country.Name}");
            this.menuOptions.Add("3", $"Add a language to {country.Name}");
            this.menuOptions.Add("4", $"Remove a language from {country.Name}");
            this.menuOptions.Add("5", $"Add a city to {country.Name}");
            this.menuOptions.Add("B", "Back to Main Menu");
            this.quitKey = "B";
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            string countryCode;
            switch (choice)
            {
                case "1": // List cities in a country
                    ListCities();
                    Pause("");
                    return true;
                case "2": // List Languages in a country
                    ListLanguages();
                    Pause("");
                    return true;
                case "3": // Add a language
                    AddNewLanguage();
                    Pause("");
                    return true;
                case "4": // Remove a language
                    RemoveLanguage();
                    Pause("");
                    return true;
                case "5": // Add a city
                    AddCity();
                    Pause("");
                    return true;
            }
            return true;
        }

        private void ListLanguages()
        {
            IList<Language> languages = languageDAO.GetLanguages(country.Code);
            SetColor(ConsoleColor.Blue);
            Console.WriteLine(Language.GetHeader());
            foreach (Language language in languages)
            {
                Console.WriteLine(language);
            }
            ResetColor();
        }

        private void ListCities()
        {
            IList<City> cities = cityDAO.GetCitiesByCountryCode(country.Code);

            SetColor(ConsoleColor.DarkYellow);
            Console.WriteLine(City.GetHeader());
            foreach (City city in cities)
            {
                Console.WriteLine(city);
            }
            ResetColor();
        }

        private void AddNewLanguage()
        {
            SetColor(ConsoleColor.DarkCyan);
            string name = GetString("What is the name of the language? ");
            bool officialOnly = GetBool("Is it official? ");
            double percentage = GetDouble("What percentage is it spoken by? ");

            Language lang = new Language
            {
                CountryCode = country.Code,
                IsOfficial = officialOnly,
                Percentage = percentage,
                Name = name
            };

            bool result = languageDAO.AddNewLanguage(lang);

            if (result)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("The new language was not inserted");
            }
            ResetColor();
        }

        private void AddCity()
        {
            SetColor(ConsoleColor.Cyan);
            string name = GetString("Name of the city: ");
            string district = GetString($"District {name} is in: ");
            int population = GetInteger($"Population of {name}: ");

            City city = new City
            {
                CountryCode = country.Code,
                Name = name,
                District = district,
                Population = population
            };
            int newId = cityDAO.AddCity(city);
            if (newId > 0)
            {
                Console.WriteLine($"City added with Id {newId}.");
            }
            else
            {
                Console.WriteLine("City was not added");
            }
            ResetColor();
        }

        private void RemoveLanguage()
        {
            SetColor(ConsoleColor.Yellow);
            string language = GetString("Which language should be removed? ");

            Language lang = new Language
            {
                CountryCode = country.Code,
                Name = language
            };

            bool result = languageDAO.RemoveLanguage(lang);

            if (result)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("The language was not found or removed.");
            }
            ResetColor();
        }


        protected override void BeforeDisplayMenu()
        {
            base.BeforeDisplayMenu();
            SetColor(ConsoleColor.Magenta);

            Console.WriteLine($"{country.Name,-39} Population: {country.Population:N0}");
            Console.WriteLine($"Head of State: {country.HeadOfState, -24} Capital: {country.CapitalName}");

            ResetColor();
        }

    }
}
