using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace SoumyaKart
{
    public class ProductRepo : IProductRepo
    {
        static string connection = "Server = DESKTOP-22HM36Q\\SQLEXPRESS; Database=SoumyaKart; Integrated Security=SSPI;";
        public List<PRODUCT> GetAllProduct()
        {
            List<PRODUCT> list = new List<PRODUCT>();

            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ProductId,Quantity,ProductCategory, ProductName FROM PRODUCT",con))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while(read.Read())
                        {
                            PRODUCT obj = new PRODUCT();

                            obj.ProductId = Convert.ToInt32(read["ProductId"]);
                            obj.Quantity = Convert.ToInt32(read["Quantity"]);
                            obj.ProductCategory = read["ProductCategory"].ToString();
                            obj.ProductName = read["ProductName"].ToString();


                            list.Add(obj);
                        }
                    }
                }
            }
            return list;
        }

        public List<PRODUCT> GetProductsByCategory(string Category)
        {
            List<PRODUCT> list = new List<PRODUCT>();

            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ProductId,ProductName,Quantity,ProductCategory FROM PRODUCT WHERE ProductCategory = @ProductCategory",con))
                {
                    cmd.Parameters.AddWithValue("@ProductCategory", Category);

                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while(read.Read())
                        {
                            PRODUCT obj = new PRODUCT();

                            obj.ProductId = Convert.ToInt32(read["ProductId"]);
                            obj.Quantity = Convert.ToInt32(read["Quantity"]);
                            obj.ProductCategory = read["ProductCategory"].ToString();
                            obj.ProductName = read["ProductName"].ToString();

                            list.Add(obj);
                        }
                    }
                }
            }
            return list;
        }

        public PRODUCT GetProductById(int Id)
        {
            PRODUCT pro = new PRODUCT();
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Quantity, ProductCategory, ProductName, ProductId FROM PRODUCT WHERE ProductId = @ProductId",con))
                {
                    cmd.Parameters.AddWithValue("@ProductId", Id);
                    
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while(read.Read())
                        {
                            pro.ProductId = Convert.ToInt32(read["ProductId"]);
                            pro.Quantity = Convert.ToInt32(read["Quantity"]);
                            pro.ProductCategory = read["ProductCategory"].ToString();
                            pro.ProductName = read["ProductName"].ToString();
                        }
                    }
                }
            }
            return pro;
        }

        public void AddProduct(string pn,string pc, int price, int qnt)
        {
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using(SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCT (ProductName, ProductCategory, Price, Quantity) VALUES (@ProductName, @ProductCategory, @Price, @Quantity)",con))
                {
                    cmd.Parameters.AddWithValue("@ProductName", pn);
                    cmd.Parameters.AddWithValue("@ProductCategory",pc);
                    cmd.Parameters.AddWithValue("@Price",price);
                    cmd.Parameters.AddWithValue("@Quantity",qnt);

                    cmd.ExecuteNonQuery();
                }
            System.Console.WriteLine("Product Add Successfuly");
            }
        }

        public void UpdateProduct(int Pi,int price2,int qnt2)
        {
             using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using(SqlCommand cmd = new SqlCommand("UPDATE PRODUCT SET (Price, Quantity) VALUES ( @Price, @Quantity) WHERE ProductId=@ProductId ",con))
                {
                    cmd.Parameters.AddWithValue("@ProductId", Pi);
                    cmd.Parameters.AddWithValue("@Price",price2);
                    cmd.Parameters.AddWithValue("@Quantity",qnt2);

                    cmd.ExecuteNonQuery();
                }
            System.Console.WriteLine("Product Update Successfuly");
            }     
        }

        public void RemoveProduct(int pi)
        {
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using(SqlCommand cmd = new SqlCommand("DELETE * FROM PRODUCT WHERE ProductId=@ProductId ",con))
                {
                    cmd.Parameters.AddWithValue("@ProductId", pi);


                    cmd.ExecuteNonQuery();
                }
            System.Console.WriteLine("Product Delete Successfuly");
            }     
        }
    }
}