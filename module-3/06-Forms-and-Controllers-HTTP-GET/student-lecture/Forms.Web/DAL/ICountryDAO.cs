using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.DAL
{
    public interface ICountryDAO
    {
        IList<Country> GetCountries();
        IList<Country> GetCountries(string continent);
        int AddCountry(Country country);
    }
}
