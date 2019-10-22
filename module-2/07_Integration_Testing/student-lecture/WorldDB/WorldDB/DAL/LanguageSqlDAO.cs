﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class LanguageSqlDAO : ILanguageDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public LanguageSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<Language> GetLanguages(string countryCode)
        {
            List<Language> languages = new List<Language>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM countrylanguage WHERE countrycode = @countrycode", conn);
                    cmd.Parameters.AddWithValue("@countrycode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Language language = RowToObject(reader);
                        languages.Add(language);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retrieving languages.");
                throw;
            }

            return languages;
        }

        private static Language RowToObject(SqlDataReader reader)
        {
            Language language = new Language();
            language.CountryCode = Convert.ToString(reader["countrycode"]);
            language.Name = Convert.ToString(reader["language"]);
            language.IsOfficial = Convert.ToBoolean(reader["isofficial"]);
            language.Percentage = Convert.ToInt32(reader["percentage"]);
            return language;
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            try
            {
                // Create a connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the command
                    SqlCommand cmd = new SqlCommand("INSERT INTO countrylanguage VALUES (@countrycode, @language, @isofficial, @percentage);", conn);
                    cmd.Parameters.AddWithValue("@countrycode", newLanguage.CountryCode);
                    cmd.Parameters.AddWithValue("@language", newLanguage.Name);
                    cmd.Parameters.AddWithValue("@isofficial", newLanguage.IsOfficial);
                    cmd.Parameters.AddWithValue("@percentage", newLanguage.Percentage);

                    // Execute the command
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred saving the new language.");
                return false;
            }

            return true;        
        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            try
            {
                // Create a connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the command
                    SqlCommand cmd = new SqlCommand("DELETE FROM countrylanguage WHERE countrycode = @countrycode and language = @language", conn);
                    cmd.Parameters.AddWithValue("@countrycode", deadLanguage.CountryCode);
                    cmd.Parameters.AddWithValue("@language", deadLanguage.Name);

                    // Execute the command
                    // TODO: Example of using ExecuteNonQuery(). This is used if no result set is expected from the query (in this case a DELETE).
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred saving the new language.");
                return false;
            }

            return true;        
        }
    }
}
