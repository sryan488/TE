﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Communities.Tests
{
    [TestClass]
    public abstract class DaoIntegrationTest
    {
        private TransactionScope transaction;

        protected string ConnectionString { get; } = @"Server=.\SqlExpress;Database=assessment;Trusted_Connection=True;";

        [TestInitialize]
        public virtual void SetUp()
        {
            transaction = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM communities";

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }
        public void GetAllCommunituesTest()
        {
            // Arrange
            IList<Community> communities;
            ICommunityDao dao = new CommunitySqlDao(ConnectionString);

            // Act
            communities = dao.GetAllCommunities();

            // Assert
            Assert.AreEqual(200, communities.Count);
        }
        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
    }
}
