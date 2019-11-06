using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Carts
{
    public class CartSqlDao : ICartDao
    {
        private readonly string connectionString;

        public CartSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Cart> GetAllCarts()
        {
            List<Cart> carts = new List<Cart>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM carts ORDER BY username ASC", conn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    carts.Add(RowToCart(r));
                }
            }
            return carts;
        }

        public void Save(Cart newCart)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO carts (username, cookie_value, created) VALUES (@u, @cv, @c); SELECT @@IDENTITY;", conn);
                cmd.Parameters.AddWithValue("@u", newCart.Username);
                cmd.Parameters.AddWithValue("@cv", newCart.CookieValue);
                cmd.Parameters.AddWithValue("@c", newCart.Created);


                newCart.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private Cart RowToCart(SqlDataReader r)
        {
            Cart c;
            string username = Convert.ToString(r["username"]);
            string cookieValue = Convert.ToString(r["cookie_value"]);
            DateTime created = Convert.ToDateTime(r["created"]);
            c = new Cart(username, cookieValue, created);

            return c;
        }
    }
}