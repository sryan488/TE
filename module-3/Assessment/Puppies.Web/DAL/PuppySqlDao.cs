using Puppies.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Puppies.Web.DAL
{
    public class PuppySqlDao : IPuppyDao
    {
        private readonly string connectionString;

        public PuppySqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all puppies
        /// </summary>
        /// <returns></returns>
        public IList<Puppy> GetPuppies()
        {
            List<Puppy> output = new List<Puppy>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM puppies", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new Puppy()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Weight = Convert.ToInt32(reader["weight"]),
                            Gender = Convert.ToString(reader["gender"]),
                            PaperTrained = Convert.ToBoolean(reader["paper_trained"]),
                        });
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return output;
        }

        /// <summary>
        /// Returns a specific puppy
        /// </summary>
        /// <returns></returns>
        public Puppy GetPuppy(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM puppies WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Puppy()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Weight = Convert.ToInt32(reader["weight"]),
                            Gender = Convert.ToString(reader["gender"]),
                            PaperTrained = Convert.ToBoolean(reader["paper_trained"]),
                        };
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return null;
        }

        /// <summary>
        /// Saves a new puppy to the system.
        /// </summary>
        /// <param name="newPuppy"></param>
        /// <returns></returns>
        public void SavePuppy(Puppy newPuppy)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO puppies (name, weight, gender, paper_trained) VALUES (@name, @weight, @gender, @paper_trained);", conn);
                    cmd.Parameters.AddWithValue("@name", newPuppy.Name);
                    cmd.Parameters.AddWithValue("@weight", newPuppy.Weight);
                    cmd.Parameters.AddWithValue("@gender", newPuppy.Gender);
                    cmd.Parameters.AddWithValue("@paper_trained", newPuppy.PaperTrained);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
