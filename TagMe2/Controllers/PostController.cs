﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TagMe2.Models;

namespace TagMe2.Controllers
{
    public class PostController : Controller
    {
        public static SqlConnection connection = new SqlConnection("Data Source=tagme.database.windows.net;Initial Catalog=tagme;Persist Security Info=True;User ID=tagme;Password=password401!");
        [HttpGet]
        public IActionResult Add()
        {
            return View();
     
        }

        [HttpPost]
        public IActionResult Add(Post Image)
        {

            Image.addToDb(connection);
            /* connection.Open();
             string commandText = "Insert into Post (UUID,text, imagetype, imageblob) VALUES(@Id,@cap,@imageType, @imageblob)";
             SqlCommand cmd = new SqlCommand(commandText, connection);

             // adding the 'converting to blob section'
             string imageName = Path.GetFileNameWithoutExtension(Image.ImageFile.FileName);
             string imageType = Image.ImageFile.ContentType;
             Stream sm = Image.ImageFile.OpenReadStream();
             BinaryReader br = new BinaryReader(sm);
             byte[] bytes = br.ReadBytes((Int32)sm.Length);



             cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
             cmd.Parameters.AddWithValue("@cap", Image.Caption);
             cmd.Parameters.AddWithValue("@imageType", imageType);
             cmd.Parameters.AddWithValue("@imageblob", bytes);

             cmd.ExecuteNonQuery();
             connection.Close();
 */
            return View();

        }

        public IActionResult commentDisplay()
        {
            Guid i = Guid.NewGuid();
            Profile prof = new Profile(null, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Sant%27Angelo_bridge%2C_dusk%2C_Rome%2C_Italy.jpg/1199px-Sant%27Angelo_bridge%2C_dusk%2C_Rome%2C_Italy.jpg", null);
            User user = new User(i, "yossri", "yossri", "khalil", prof);
            Address location = new Address("calgary","canada","AB",1.0,1.0);
            connection.Open();
            SqlCommand command = new SqlCommand("Select imageblob from Post where text=@zip", connection);
            command.Parameters.AddWithValue("@zip", "italy1");

            //SqlDataReader reader = command.ExecuteReader();
            byte[] bytes = (byte[])command.ExecuteScalar();
            string strBase64 = Convert.ToBase64String(bytes);
            string url = "data:Image/png;base64,"+strBase64;




            Post temp = new Post(i, url, location, user, "hell ya", 5, null);

          //  Post temp = new Post(i, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Sant%27Angelo_bridge%2C_dusk%2C_Rome%2C_Italy.jpg/1199px-Sant%27Angelo_bridge%2C_dusk%2C_Rome%2C_Italy.jpg", location, user, "hell ya", 5, null);


            return View(temp);
        }

        [HttpGet]
        public IActionResult Search(string tag)
        {
            connection.Open();
            string commandText = "SELECT * FROM (Post AS p JOIN PostTags AS pt ON pt.PostID = p.UUID) WHERE pt.Tag = '" + tag + "' ;";
            SqlCommand cmd = new SqlCommand(commandText, connection);
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adapter.Fill(table);
            List<Post> postsFound = new List<Post>();

           
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                Guid a = Guid.Parse(row["UUID"].ToString());

                byte[] bytes = (byte[])row["imageblob"];
                string strBase64 = Convert.ToBase64String(bytes);
                string url = "data:Image/png;base64," + strBase64;
                postsFound.Add(new Post(a, url, null, null, row["text"].ToString(), 5, null)); i++;
            }
            connection.Close();
            return View("allimageView", postsFound);
        }

    }
}