﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TagMe2.Models.Query;

/// <summary>
/// Handles read commands for comments.
/// </summary>
namespace TagMe2.Models.Comments
{
    public class CommentQueryHandler
    {
        public static Comment displayComment(Guid id)
        {
            //have query here to look for comment based on ID

            string temp = "SELECT * " +
                          "FROM CommentEvent" +
                          "WHERE UUID = {0} ;";

            string queryString = string.Format(temp, id);

            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            SqlDataReader reader = command.ExecuteReader();

            Guid ID;
            Guid Parent_ID;
            Guid Post_ID;
            string Text;
            Guid User_ID;


            reader.Read();
           
                ID = Guid.Parse(reader["UUID"].ToString());
                Parent_ID = Guid.Parse(reader["parent_UUID"].ToString());
                Post_ID = Guid.Parse(reader["post_ID"].ToString());
                Text = reader["text"].ToString();
                User_ID = Guid.Parse(reader["author"].ToString());
                Comment myComment = new Comment(ID, Parent_ID, Post_ID, Text, new User());

 
    

            reader.Close();
            return myComment;
        }
    }
}
