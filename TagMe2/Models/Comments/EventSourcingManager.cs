using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TagMe2.Models.Query;

namespace TagMe2.Models.Comments
{
    public static class EventSourcingManager
    {
        /// <summary>
        /// Will retrieve comments under common post.
        /// </summary>
        /// <param name="postID"></param>
        public static LinkedList<Comment> retrieveCommentsFromPost(Guid postID)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DatabaseTagMe2;Trusted_Connection=True;MultipleActiveResultSets=true";

            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            LinkedList<Comment> commentList = new LinkedList<Comment>();

            string temp = "SELECT * FROM CommentEvent WHERE post_ID = @ID";
           // string queryString = string.Format(temp,postID);

            // SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
             SqlCommand command = new SqlCommand(temp, myConnection);
            command.Parameters.AddWithValue("@ID", postID);

            SqlDataReader reader = command.ExecuteReader();
            Guid ID;
            Guid Parent_ID;
            Guid Post_ID;
            string Text;
            string User_ID;

            while (reader.Read())
            {
               ID = Guid.Parse(reader["ID"].ToString());
               Parent_ID = Guid.Parse(reader["parent_ID"].ToString());
               Post_ID = Guid.Parse(reader["post_ID"].ToString());
               Text = reader["text"].ToString();
                User_ID = reader["author"].ToString();
               Comment myComment= new Comment(ID, Parent_ID, Post_ID, Text,new User(),SearchChildComments(ID));

               commentList.AddLast(myComment);
            }

            reader.Close();
            myConnection.Close();
            return commentList;
        }

        public static LinkedList<Comment> SearchChildComments(Guid parentID)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DatabaseTagMe2;Trusted_Connection=True;MultipleActiveResultSets=true";

            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            // this returns list of comments, child comments to a parent id

            LinkedList<Comment> childComment = new LinkedList<Comment>();
            string temp = "SELECT * FROM CommentEvent WHERE parent_ID = @ID";
            //string queryString = string.Format(temp, parentID);

            SqlCommand command = new SqlCommand(temp, myConnection);
            command.Parameters.AddWithValue("@ID", parentID);
            SqlDataReader reader = command.ExecuteReader();
            Guid ID;
            Guid Parent_ID;
            Guid Post_ID;
            string Text;
            string User_ID;


            while (reader.Read())
            {
                ID = Guid.Parse(reader["ID"].ToString());
                Parent_ID = Guid.Parse(reader["parent_ID"].ToString());
                Post_ID = Guid.Parse(reader["post_ID"].ToString());
                Text = reader["text"].ToString();
                User_ID = reader["author"].ToString();
                Comment myComment = new Comment(ID, Parent_ID, Post_ID, Text, new User(),SearchChildComments(ID));

                childComment.AddLast(myComment);
            }

            reader.Close();
            myConnection.Close();

            return childComment;


        }

    }
}
