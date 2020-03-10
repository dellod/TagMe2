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
            string connectionString = "Data Source=tagme.database.windows.net;Initial Catalog=tagme;User ID=tagme;Password=********;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
