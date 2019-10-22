using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CityFileDAO : ICityDAO
    {
        private string filePath;
        private List<City> cities;
        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="filePath"></param>
        public CityFileDAO(string filePath)
        {
            this.filePath = filePath;
            LoadFromFile();
        }

        public int AddCity(City city)
        {
            // Find the next Id
            int maxId = cities.Max(c => c.CityId);
            city.CityId = maxId + 1;
            cities.Add(city);
            SaveToFile();
            return city.CityId;
        }

        public IList<City> GetAllCities()
        {
            //TODO: Example of LINQ OrderByDescinding
            return cities.OrderByDescending(c => c.Population).ToList();
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            //TODO: Example of LINQ Where & OrderByDescinding
            return this.cities.Where(c => c.CountryCode == countryCode.ToUpper()).OrderByDescending(c => c.Population).ToList();
        }

        private void LoadFromFile()
        {
            cities = new List<City>();

            if (File.Exists(filePath))
            {
                using (StreamReader rdr = new StreamReader(filePath))
                {
                    while (!rdr.EndOfStream)
                    {
                        string line = rdr.ReadLine();
                        if (line.Trim().Length == 0)
                        {
                            continue;
                        }
                        string[] fields = line.Split("|");
                        City city = new City();
                        city.CityId = int.Parse(fields[0]);
                        city.CountryCode = fields[1];
                        city.District = fields[2];
                        city.Name = fields[3];
                        city.Population = int.Parse(fields[4]);
                        cities.Add(city);
                    }
                }
            }
        }

        private void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (City city in cities)
                {
                    string line = string.Join("|", city.CityId, city.CountryCode,
                        city.District, city.Name, city.Population);
                    sw.WriteLine(line);
                }
            }
        }

    }
}
