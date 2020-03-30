using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models.Query
{
    public static class connectDatabase
    {
        public static SqlConnection myConnection
        {
            get; set;
        }
        

        public static void connectToDatabase()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DatabaseTagMe2;Trusted_Connection=True;MultipleActiveResultSets=true";

            SqlConnection myConnection = new SqlConnection(connectionString);
         
                try
                {
                    myConnection.Open();
                    if (myConnection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Success");
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
