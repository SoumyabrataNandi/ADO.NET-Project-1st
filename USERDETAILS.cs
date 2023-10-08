using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace SoumyaKart
{
    public class USERDETAILS
    {
        static string connection = "Server = DESKTOP-22HM36Q\\SQLEXPRESS; Database=SoumyaKart; Integrated Security=SSPI;";

        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public bool IsValidUser(string UName, string pass)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT UserId FROM _USER WHERE UserName = @UserName AND UserPassword = @UPassword", conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", UName);
                    cmd.Parameters.AddWithValue("@UPassword", pass);

                    var a = cmd.ExecuteScalar();

                    if (a !=  null)
                    {
                        Console.WriteLine($"WelCome {UName} Your UserId is {a}");
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong Input");
                        return false;
                    }
                }

            }
        }

        public bool AdminCheckLogin (string AdminName, string AdminPassword)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ADMINDETAILS WHERE AdminName = @UserName AND AdminPassword = @UserPassword",con))
                {
                    cmd.Parameters.AddWithValue("@UserName", AdminName);
                    cmd.Parameters.AddWithValue("@UserPassword",AdminPassword);

                    int vf = Convert.ToInt32(cmd.ExecuteScalar());

                    if(vf > 0)
                    {
                        System.Console.WriteLine($"WELECOME {AdminName} To The Store Section");
                        return true;
                    }
                    return false;
                }
            }
        }

        public void NewUser(string UName, string pass)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO _USER(UserName, UserPassword) Values(@UserName,@UPassword)", conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", UName);
                    cmd.Parameters.AddWithValue("@UPassword", pass);

                    cmd.ExecuteNonQuery();

                   System.Console.WriteLine("Wlecome To Our App");
                }

            }
        }
    }
}