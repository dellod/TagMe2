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
 
            string temp = "INSERT INTO CommentEvent VALUES({0},{1},{2},{3},{4},{5});";
            string queryString = string.Format(temp, comment.ID, comment.Parent_ID, comment.Text, comment.Author, 1);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            command.ExecuteNonQuery();
        }

        public static void DeleteComment(Comment comment)
        {
            string temp = "INSERT INTO CommentEvent VALUES({0},{1},{2},{3},{4},{5});";
            string queryString = string.Format(temp, comment.ID, comment.Parent_ID, comment.Text, comment.Author, 2);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            command.ExecuteNonQuery();
        }

        public static void EditComment(Comment comment)
        {
            string temp = "INSERT INTO CommentEvent VALUES({0},{1},{2},{3},{4},{5});";
            string queryString = string.Format(temp, comment.ID, comment.Parent_ID, comment.Text, comment.Author, 3);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            command.ExecuteNonQuery();
        }
    }

        
}
    
