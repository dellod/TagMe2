using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TagMe2.Models.Comments;

namespace TagMe2.Models.Query
{
    public static class CommandQuery
    {
       
        public static void AddComment(Comment comment)
        {
            
            string queryString = "CREATE TABLE test(myuser int);";
            
            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            command.ExecuteNonQuery();
        }

        public static void DeleteComment(Comment comment)
        {
            string queryString = "CREATE TABLE test(myuser int);";
        }

        public static void EditComment(Comment comment)
        {
            string queryString = "CREATE TABLE test(myuser int);";
        }
    }
}
