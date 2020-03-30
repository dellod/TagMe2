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
        static void AddNewComment(Comment comment)
        {
            string temp = "INSERT INTO CommentEvent VALUES({0},{1},{2},{3},{4},{5});";
            string queryString = string.Format(temp, comment.ID, comment.Parent_ID, comment.Text, comment.Author, 1);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            command.ExecuteNonQuery();
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
