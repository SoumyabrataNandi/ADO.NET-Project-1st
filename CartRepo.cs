using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace SoumyaKart
{
    public class CartRepo : ICartRepo
    {
        static string connection = "Server = DESKTOP-22HM36Q\\SQLEXPRESS; Database=SoumyaKart; Integrated Security=SSPI;";
        public List<CART> GetCartItems(string UserId)
        {
            List<CART> list = new List<CART>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT CartId, ProductId, Quantity FROM CART WHERE UserId = @UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            CART obj = new CART();

                            obj.ProductId = Convert.ToInt32(read["ProductId"]);
                            obj.CartId = read["CartId"].ToString();
                            obj.Quantity = Convert.ToInt32(read["Quantity"]);

                            list.Add(obj);
                        }
                    }
                }
            }
            return list;
        }

        public void RemoveProductFromCart(int ProductId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM CART WHERE ProductId = @ProductId", con))
                {
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);

                    cmd.ExecuteNonQuery();
                }
            }
            System.Console.WriteLine("Product Remove Successfuly");
        }

        public void UpdateProductQuantity(int ProductId, int Quantity)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE CART SET Product = @ProductId ,Quantity = @Quantity WHERE ProductId = @ProductId AND Quantity = @Quantity", con))
                {
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    cmd.Parameters.AddWithValue("Quantity", Quantity);

                    cmd.ExecuteNonQuery();
                }
            }
            System.Console.WriteLine("Product Update Successfuly");
        }

        public void ConfirmOrder(string UserId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO _ORDER (CartId, UserId) SELECT CartId, UserId FROM CART WHERE UserId = @UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    cmd.ExecuteNonQuery();
                }
            }
            System.Console.WriteLine("Product Order Successfuly");
        }

        public void AddToCart(int ProductId, int Quentity, string UserId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                Guid cartid;

                using (SqlCommand cmd = new SqlCommand("SELECT CartId FROM CART WHERE UserId = @UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    var check = cmd.ExecuteScalar();

                    if (check != null)
                    {
                        cartid = (Guid)check;
                    }
                    else
                    {
                        cartid = Guid.NewGuid();
                    }
                }

                int prodId = 0;

                int quan = 0;

                using (SqlCommand comm = new SqlCommand("SELECT ProductId, Quantity FROM CART WHERE ProductId = @ProductId ", con))
                {

                    comm.Parameters.AddWithValue("@ProductId", ProductId);

                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        prodId = Convert.ToInt32(reader["ProductId"]);

                        quan = Convert.ToInt32(reader["Quantity"]);
                    }

                    comm.ExecuteNonQuery();
                }

                if (prodId == ProductId)
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE CART SET Quantity = @Quantity WHERE ProductId = @ProductId", con))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", prodId);
                        
                        int a = quan + Quentity;

                        cmd.Parameters.AddWithValue("@Quantity", a);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Quantity increased");
                    }
                }

                else

                {
                    using (SqlCommand cmd1 = new SqlCommand("INSERT INTO CART (ProductId, Quantity, UserId, CartId) VALUES (@ProductId, @Quentity, @UserId, @CartId)", con))
                    {
                        cmd1.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd1.Parameters.AddWithValue("@Quentity", Quentity);
                        cmd1.Parameters.AddWithValue("@UserId", UserId);

                        cmd1.Parameters.AddWithValue("@CartId", cartid);

                        cmd1.ExecuteNonQuery();
                    }
                }
            }
            System.Console.WriteLine("Product Add To Cart Successfuly");
        }
    }
}