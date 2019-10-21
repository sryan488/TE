using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    interface ICityDAO
    {
        List<City> GetAllCities();
        List<City> GetCitiesForCountryCode(string countryCode);
        bool AddCity(City city);
    }
}
