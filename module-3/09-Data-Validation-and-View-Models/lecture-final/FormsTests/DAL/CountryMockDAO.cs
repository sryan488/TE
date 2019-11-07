using Forms.Web.DAL;
using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsTests.DAL
{
    class CountryMockDAO : ICountryDAO
    {
        private List<Country> countries = new List<Country>()
        {
            new Country("CC1", "Country1", "Cont1", "Region1", 10000, 1700, 1000000, 1),
            new Country("CC2", "Country2", "Cont2", "Region2", 20000, null, 2000000, 2),
        };

        public int AddCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public IList<Country> GetCountries()
        {
            return new List<Country>(countries);
        }

        public IList<Country> GetCountries(string continent)
        {
            throw new NotImplementedException();
        }
    }
}
