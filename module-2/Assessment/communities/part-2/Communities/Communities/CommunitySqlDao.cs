using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Communities
{
    public class CommunitySqlDao : ICommunityDao
    {
        private readonly string connectionString;

        public CommunitySqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Community> GetAllCommunities()
        { 
            List<Community> communities = new List<Community>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM communities ORDER BY name ASC", conn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    communities.Add(RowToCommunity(r));   
                }
            }
            return communities;
        }

        public void Save(Community newCommunity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO communities (name, created, latitude, longitude, live) VALUES (@n, @c, @la, @lo, @iL); SELECT @@IDENTITY;", conn);
                cmd.Parameters.AddWithValue("@n", newCommunity.Name);
                cmd.Parameters.AddWithValue("@c", newCommunity.Created);
                cmd.Parameters.AddWithValue("@la", newCommunity.Latitude);
                cmd.Parameters.AddWithValue("@lo", newCommunity.Longitude);
                cmd.Parameters.AddWithValue("@iL", newCommunity.IsLive);

                newCommunity.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private Community RowToCommunity(SqlDataReader r)
        {
            Community c;
            string name = Convert.ToString(r["name"]);
            DateTime created = Convert.ToDateTime(r["created"]);
            decimal latitude = Convert.ToDecimal(r["latitude"]);
            decimal longitude = Convert.ToDecimal(r["longitude"]);
            bool isLive = Convert.ToBoolean(r["live"]);
            c = new Community(name, created, latitude, longitude, isLive);

            return c;
        }
    }
}