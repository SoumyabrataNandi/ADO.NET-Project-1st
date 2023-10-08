using System;
using System.Data.SqlClient;

namespace SoumyaKart
{
    public class feedback
    {
        static string connection = "Server = DESKTOP-22HM36Q\\SQLEXPRESS; Database=SoumyaKart; Integrated Security=SSPI;";

        public string fbuser { get; set;}

        public void Userfb(string input)
        {
             using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO FEEDBACK (FeedBack) VALUES (@fb);", conn))
                {
                    cmd.Parameters.AddWithValue("@fb", input);

                    cmd.ExecuteNonQuery();

                    System.Console.WriteLine("Thank You For Your FeedBack....");
                }

            }
        }
    }
    
}