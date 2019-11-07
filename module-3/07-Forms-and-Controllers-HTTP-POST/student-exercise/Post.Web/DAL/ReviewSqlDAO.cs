using Post.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.DAL
{
    public class ReviewSqlDAO : IReviewDAO
    {
        private readonly string connectionString;

        public ReviewSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all reviews
        /// </summary>
        /// <returns></returns>
        public IList<Review> GetAllReviews()
        {

            List<Review> output = new List<Review>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = @"SELECT * FROM reviews";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(RowToObject(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        /// <summary>
        /// Saves a new review to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        public int SaveReview(Review newReview)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO reviews (username, rating, review_title, review_text, review_date) VALUES (@username, @r, @rt, @rtext, @rd);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", newReview.Username);
                    cmd.Parameters.AddWithValue("@r", newReview.Rating);
                    cmd.Parameters.AddWithValue("@rt", newReview.ReviewTitle);
                    cmd.Parameters.AddWithValue("@rtext", newReview.ReviewText);
                    cmd.Parameters.AddWithValue("@rd", DateTime.Now);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
           
        }
        private Review RowToObject(SqlDataReader reader)
        {
            Review review = new Review();
            review.ReviewId = Convert.ToInt32(reader["review_id"]);
            review.Username = Convert.ToString(reader["username"]);
            review.Rating = Convert.ToInt32(reader["rating"]);
            review.ReviewTitle = Convert.ToString(reader["review_title"]);
            review.ReviewText = Convert.ToString(reader["review_text"]);
            review.ReviewDate = Convert.ToDateTime(reader["review_date"]);
            return review;
        }
    }
}
