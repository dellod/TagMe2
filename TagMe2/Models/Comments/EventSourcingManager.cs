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
            LinkedList<Comment> commentList = new LinkedList<Comment>();
            // TODO need to query based on post ID, then after query by order
            //          ORDER will be oldest to newest, so the first comment will be directly attached to the post, and the newest posts will follow afterwards.

            string temp = "SELECT * " +
                          "FROM CommentEvent" +
                          "WHERE post_ID = {0} ;";
            string queryString = string.Format(temp,postID);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            SqlDataReader reader = command.ExecuteReader();

            Guid ID;
            Guid Parent_ID;
            Guid Post_ID;
            string Text;
            Guid User_ID;



            while (reader.Read())
            {
               ID = Guid.Parse(reader["UUID"].ToString());
               Parent_ID = Guid.Parse(reader["parent_UUID"].ToString());
               Post_ID = Guid.Parse(reader["post_ID"].ToString());
               Text = reader["text"].ToString();
               User_ID = Guid.Parse(reader["author"].ToString());
               Comment myComment= new Comment(ID, Parent_ID, Post_ID, Text,new User(),SearchChildComments(ID));

               commentList.AddLast(myComment);
            }

            reader.Close();
            // FIrst query the comment with parent_id that matches the post_id
            // then query the next comment that has parent_id that matches the last comment
            // keep going
            return commentList;
        }

        public static LinkedList<Comment> SearchChildComments(Guid parentID)
        {

            LinkedList<Comment> childComment = new LinkedList<Comment>();
            string temp = "SELECT * " +
                          "FROM CommentEvent" +
                          "WHERE parent_UUID = {0} ;";
            string queryString = string.Format(temp, parentID);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            SqlDataReader reader = command.ExecuteReader();

            Guid ID;
            Guid Parent_ID;
            Guid Post_ID;
            string Text;
            Guid User_ID;



            while (reader.Read())
            {
                ID = Guid.Parse(reader["UUID"].ToString());
                Parent_ID = Guid.Parse(reader["parent_UUID"].ToString());
                Post_ID = Guid.Parse(reader["post_ID"].ToString());
                Text = reader["text"].ToString();
                User_ID = Guid.Parse(reader["author"].ToString());
                Comment myComment = new Comment(ID, Parent_ID, Post_ID, Text, new User(),SearchChildComments(ID));

                childComment.AddLast(myComment);
            }

            reader.Close();
            // FIrst query the comment with parent_id that matches the post_id
            // then query the next comment that has parent_id that matches the last comment
            // keep going
            return childComment;


        }

    }
}
