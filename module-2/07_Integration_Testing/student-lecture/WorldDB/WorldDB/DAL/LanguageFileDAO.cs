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
    public class LanguageFileDAO : ILanguageDAO
    {
        private string filePath;
        private List<Language> languages;
        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="filePath"></param>
        public LanguageFileDAO(string filePath)
        {
            this.filePath = filePath;
            LoadFromFile();
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            languages.Add(newLanguage);
            SaveToFile();
            return true;
        }

        public IList<Language> GetLanguages(string countryCode)
        {
            countryCode = countryCode.ToUpper();
            return languages.Where(l => l.CountryCode == countryCode).ToList();
        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            Language language = languages.Where(l => deadLanguage.CountryCode.ToUpper() == l.CountryCode && deadLanguage.Name.ToUpper() == l.Name.ToUpper()).FirstOrDefault();
            if (language == null)
            {
                return false;
            }
            else
            {
                languages.Remove(language);
                return true;
            }
        }

        private void LoadFromFile()
        {
            languages = new List<Language>();

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
                        Language language = new Language();
                        language.CountryCode = fields[0];
                        language.Name = fields[1];
                        language.IsOfficial = bool.Parse(fields[2]);
                        language.Percentage = double.Parse(fields[3]);
                        languages.Add(language);
                    }
                }
            }
        }

        private void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Language language in languages)
                {
                    string line = string.Join("|", language.CountryCode, language.Name,
                        language.IsOfficial, language.Percentage);
                    sw.WriteLine(line);
                }
            }
        }

    }
}
