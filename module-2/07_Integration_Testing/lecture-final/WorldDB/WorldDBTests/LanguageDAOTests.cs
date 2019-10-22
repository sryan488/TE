using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using WorldDB.DAL;
using WorldDB.Models;

namespace WorldDBTests
{
    [TestClass]
    public class LanguageDAOTests
    {
        private TransactionScope transaction;
        const string connectionString = "Server=.\\SQLEXPRESS;Database=World;Trusted_Connection=True;";
        private int newCityId = 0;
        [TestInitialize]
        public void Setup()
        {
            // Begin a transaction
            this.transaction = new TransactionScope();
            string script;
            // Load a script file to setup the db the way we want it
            using (StreamReader sr = new StreamReader("test_setup.sql"))
            {
                script = sr.ReadToEnd();
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(script, conn);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    newCityId = Convert.ToInt32(rdr["NewCity"]);
                }
            }


        }

        [TestCleanup]
        public void Cleanup()
        {
            // Roll back the transaction
            this.transaction.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            LanguageSqlDAO dao = new LanguageSqlDAO(connectionString);

            // Act
            IList<Language> list = dao.GetLanguages("ZZZ");
            IList<Language> list2 = dao.GetLanguages("AAA");

            // Assert 
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(0, list2.Count);
        }
    }
}
