using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models
{
    public class Query
    {

        public static void query()
        {
            string queryString = "CREATE TABLE test(myuser int);";
            string connectionString = "Server=tcp:tagme.database.windows.net,1433;Initial Catalog=tagme;Persist Security Info=False;User ID=tagme;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Connection failed");
                }

            }

        }
    }
}
