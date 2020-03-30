using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TagMe2.Models.Query;

namespace TagMe2.Models.Comments
{
    public static class CommentEventHandler
    {

        public static int CurrentNum
        {
            get; set;
        }
        public static void HandleNextEvent()
        {
            if (CurrentNum.Equals(null))
            {

                CurrentNum = 0;
                /*string queryString0 = "SELECT* FROM CommentEvent WHERE num = 0;";
                SqlCommand command0 = new SqlCommand(queryString0, connectDatabase.myConnection);
                SqlDataReader reader0 = command0.ExecuteReader();

                reader0.Read();
                CurrentNum++UUID"].ToString());*/
            }

            string temp = "SELECT * " +
                          "FROM CommentEvent" +
                          "WHERE num = {0} ;";

            string queryString = string.Format(temp, CurrentNum);
            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int state = Int16.Parse(reader["action"].ToString());

            Guid ID = Guid.Parse(reader["UUID"].ToString());
            Guid parent_ID = Guid.Parse(reader["parent_UUID"].ToString());
            Guid post_ID = Guid.Parse(reader["post_ID"].ToString());
            string text = reader["text"].ToString();
            string author = reader["author"].ToString();

            CurrentNum++;

            if (state == 1)
            {
                Comment myComment = new Comment(ID, parent_ID, post_ID, text, new User(), EventSourcingManager.SearchChildComments(ID));

                //  should pass comment to front-end in order to dispaly on the site
                //
                //

                // AddCommentToFrontEnd();
            }


        }
   
        }

    /*
        public static void DeleteComment(Comment comment)
        {
  
        }

        public static void EditComment(Comment comment)
        {

        }*/
    }

