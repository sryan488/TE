using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class City
    {
        public int CityId { get;  set; }
        public string Name { get;  set; }
        public string CountryCode { get;  set; }
        public string CountryName { get; set; }
        public string District { get;  set; }
        public int Population { get;  set; }

        public City() { }

        public City(int cityId, String name, string countryCode, string countryName, string district, int population)
        {
            CityId = cityId;
            Name = name;
            CountryCode = countryCode;
            CountryName = countryName;
            District = district;
            Population = population;
        }
    }
}
