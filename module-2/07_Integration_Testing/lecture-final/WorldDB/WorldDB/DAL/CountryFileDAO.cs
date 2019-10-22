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
    public class CountryFileDAO : ICountryDAO
    {
        private string filePath;
        private List<Country> countries;
        /// <summary>
        /// Creates a new sql-based country dao.
        /// </summary>
        /// <param name="filePath"></param>
        public CountryFileDAO(string filePath)
        {
            this.filePath = filePath;
            LoadFromFile();
        }

        public IList<Country> GetCountries()
        {
            //TODO: Example of LINQ OrderBy
            return countries.OrderBy(c => c.Name).ToList();
        }

        public IList<Country> GetCountries(string continent)
        {
            continent = continent.ToLower();
            //TODO: Example of LINQ Where & OrderBy
            return countries.Where(c => c.Continent.ToLower() == continent).OrderBy(c => c.Name).ToList();
        }

        public Country GetCountryByCode(string countryCode)
        {
            countryCode = countryCode.ToUpper();
            //TODO: Example of LINQ Where & FirstOrDefault
            return countries.Where(c => c.Code == countryCode).FirstOrDefault();
        }

        private void LoadFromFile()
        {
            countries = new List<Country>();

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
                        Country country = new Country();
                        country.Code = fields[0];
                        country.Name = fields[1];
                        country.Continent = fields[2];
                        countries.Add(country);
                    }
                }
            }
        }

        private void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Country country in countries)
                {
                    string line = string.Join("|", country.Code, country.Name, country.Continent);
                    sw.WriteLine(line);
                }
            }
        }

    }
}
