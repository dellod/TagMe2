using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TagMe2.Models.Comments;
using TagMe2.Models.Query;
namespace TagMe2.Models.Comments
{
    /// <summary>
    /// Handles updates for comments.
    /// </summary>
    public static class CommentCommandHandler
    {
        static void execute(Comment comment)
        {
            /* Commands command = comment.Command;
             switch(command)
             {
                 case Commands.AddNewComment:
                     AddNewComment(comment);
                     break;
                 case Commands.DeleteComment:
                     DeleteComment(comment);
                     break;
                 case Commands.EditComment:
                     EditComment(comment);
                     break;

             }*/

           // AddNewComment(comment); 
        }
        public static void AddNewComment(Comment comment)
        {
            // TODO: this format was given me a headache, so I edited everything, like always lol
            /*
            string temp = "INSERT INTO CommentEvent VALUES({0},{1},{2},{3},{4},{5});";
            string queryString = string.Format(temp, comment.ID, comment.Parent_ID, comment.Text, comment.Author, 1);
            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            command.ExecuteNonQuery();
            */

            //parentID: can be a post ID if you are replying directly to post,
            //        : can be the parent comment id, if you are replying to another comment
            // comment author will be null for now I guess
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DatabaseTagMe2;Trusted_Connection=True;MultipleActiveResultSets=true";

            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string queryString = "INSERT INTO CommentEvent(ID, parent_ID, text, author, post_ID, num) VALUES(@ID, @parent_ID, @text, @author, @post_ID, @num)";
            SqlCommand cmd = new SqlCommand(queryString, myConnection);
            cmd.Parameters.AddWithValue("@ID", comment.ID);
            cmd.Parameters.AddWithValue("@parent_ID", comment.Parent_ID);
            cmd.Parameters.AddWithValue("@text", comment.Text);
            cmd.Parameters.AddWithValue("@author", comment.Author.ToString());
            cmd.Parameters.AddWithValue("@post_ID", comment.Post_ID);
            cmd.Parameters.AddWithValue("@num", 1);
            cmd.ExecuteNonQuery();

            myConnection.Close();
        }
        /*
        static void DeleteComment(Comment comment)
        {
            string temp = "INSERT INTO CommentEvent VALUES({0},{1},{2},{3},{4},{5});";
            string queryString = string.Format(temp, comment.ID, comment.Parent_ID, comment.Text, comment.Author, 2);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            command.ExecuteNonQuery();
        }

        static void EditComment(Comment comment)
        {
            string temp = "INSERT INTO CommentEvent VALUES({0},{1},{2},{3},{4},{5});";
            string queryString = string.Format(temp, comment.ID, comment.Parent_ID, comment.Text, comment.Author, 3);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            command.ExecuteNonQuery();
        }
        */
    }
}
