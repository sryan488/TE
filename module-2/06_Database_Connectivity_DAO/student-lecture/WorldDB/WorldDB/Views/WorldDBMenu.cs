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
    public class WorldDBMenu : CLIMenu
    {
        // TODO: Store the Interfaces to our data objects



        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public WorldDBMenu() : base()
        {
            // TODO: Change this constructor to require city, country and language daos

            // TODO: Assign the Interfaces to protected variables so we can use them later
        }

        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "List Countries");
            this.menuOptions.Add("2", "List Countries on a continent");
            this.menuOptions.Add("3", "Select a country");
            this.menuOptions.Add("Q", "Quit");
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
                case "1": // List Countries
                    // Show user a list of items available
                    ListCountries();
                    Pause("");
                    return true;
                case "2": // List Countries on a continent
                    string continent = GetString("Enter the Continent Name: ");
                    ListCountries(continent);
                    Pause("");
                    return true;
                case "3": // Show the Country sub-menu
                    countryCode = GetString("Enter the Country Code: ");

                    // TODO: Lookup the country (GetCountryByCode) and pass that into the country submenu
                    Country country = null;
                    if (country == null)
                    {
                        Pause($"Sorry, country '{countryCode}' does not exist.");
                        return true;
                    }
                    // TODO: Code was found, invoke the Country menu
                    CountryMenu menu = new CountryMenu(country);
                    menu.Run();
                    return true;
            }
            return true;
        }

        private void ListCountries(string continent)
        {
            // TODO: Get the list of countries for a continent (GetCountries)
            IList<Country> countries = new List<Country>();

            SetColor(ConsoleColor.Green);
            Console.WriteLine(Country.GetHeader());
            foreach (Country country in countries)
            {
                Console.WriteLine(country);
            }
            ResetColor();
        }

        private void ListCountries()
        {
            // TODO: Get the list of countries for a continent (GetCountries)
            IList<Country> countries = new List<Country>();

            SetColor(ConsoleColor.Blue);
            Console.WriteLine(Country.GetHeader());
            foreach(Country country in countries)
            {
                Console.WriteLine(country);
            }
            ResetColor();
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }


        private void PrintHeader()
        {
            Console.WriteLine(@" _    _  _____ ______  _     ______     ______   ___   _____   ___  ______   ___   _____  _____ ");
            Console.WriteLine(@"| |  | ||  _  || ___ \| |    |  _  \    |  _  \ / _ \ |_   _| / _ \ | ___ \ / _ \ /  ___||  ___|");
            Console.WriteLine(@"| |  | || | | || |_/ /| |    | | | |    | | | |/ /_\ \  | |  / /_\ \| |_/ // /_\ \\ `--. | |__  ");
            Console.WriteLine(@"| |/\| || | | ||    / | |    | | | |    | | | ||  _  |  | |  |  _  || ___ \|  _  | `--. \|  __| ");
            Console.WriteLine(@"\  /\  /\ \_/ /| |\ \ | |____| |/ /     | |/ / | | | |  | |  | | | || |_/ /| | | |/\__/ /| |___ ");
            Console.WriteLine(@" \/  \/  \___/ \_| \_|\_____/|___/      |___/  \_| |_/  \_/  \_| |_/\____/ \_| |_/\____/ \____/ ");
        }
    }
}
