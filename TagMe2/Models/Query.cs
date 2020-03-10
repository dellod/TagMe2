using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models
{
    public class Query
    {
        // testing
        public static void query()
        {
            string queryString = "CREATE TABLE test(myuser int);";
            string connectionString = "Data Source=tagme.database.windows.net;Initial Catalog=tagme;Persist Security Info=True;User ID=tagme;Password=password401!";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Success");

                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        Console.WriteLine("Not open");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Connection failed***************");
                }

            }

        }
    }
}
