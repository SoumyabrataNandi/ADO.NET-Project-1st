using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;

namespace SoumyaKart
{
    public class OrderRepo : IOrderRepo
    {
        static string connection = "Server = DESKTOP-22HM36Q\\SQLEXPRESS; Database=SoumyaKart; Integrated Security=SSPI;";
        public List<_ORDER> ViewOrdersByUserId(string UserId)
        {
            List<_ORDER> list = new List<_ORDER>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT OrderId, CartId, OrderDate FROM _ORDER WHERE UserId = @UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _ORDER ord = new _ORDER();
                            ord.OrderId = Convert.ToInt32(reader["OrderId"]);
                            ord.CartId = reader["CartId"].ToString();
                            ord.OrderDate = Convert.ToDateTime(reader["OrderDate"]);

                            list.Add(ord);
                        }
                    }
                }
            }
            return list;
        }

    }

}




