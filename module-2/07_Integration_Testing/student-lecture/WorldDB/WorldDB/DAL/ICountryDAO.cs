using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICountryDAO
    {

        /// <summary>
        /// Get the country identified by the given country code.
        /// </summary>
        /// <param name="countryCode">Code (identifier) of the country to lookup</param>
        /// <returns>A country object, or NULL if the code is invalid</returns>
        Country GetCountryByCode(string countryCode);

        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns></returns>
        IList<Country> GetCountries();

        /// <summary>
        /// Gets all countries for a continent.
        /// </summary>
        /// <param name="continent">The continent to filter by.</param>
        /// <returns></returns>
        IList<Country> GetCountries(string continent);
    }
}
