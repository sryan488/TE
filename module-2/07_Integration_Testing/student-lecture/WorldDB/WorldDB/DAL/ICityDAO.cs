using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICityDAO
    {
        /// <summary>
        /// Get all cities in the DB
        /// </summary>
        /// <returns>List of cities</returns>
        IList<City> GetAllCities();

        /// <summary>
        /// Gets all cities provided a country code.
        /// </summary>
        /// <param name="countryCode">The country code to search for.</param>
        /// <returns></returns>
        IList<City> GetCitiesByCountryCode(string countryCode);

        /// <summary>
        /// Adds a new city.
        /// </summary>
        /// <param name="city">The city to add.</param>
        int AddCity(City city);
    }
}
