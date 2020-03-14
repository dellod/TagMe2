using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TagMe2.Models;

namespace TagMe2.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
     
        }

        [HttpPost]
        public IActionResult Add(Post Image)
        {
            
            
                SqlConnection connection = new SqlConnection("Data Source=tagme.database.windows.net;Initial Catalog=tagme;Persist Security Info=True;User ID=tagme;Password=password401!");
                connection.Open();
                string commandText = "Insert into Post (UUID,text, image_url) VALUES(@Id,@tx,@url)";
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@Id", 369);
                cmd.Parameters.AddWithValue("@tx", "asdfasdf");
                cmd.Parameters.AddWithValue("@url", "adfadsf");

              
                cmd.ExecuteNonQuery();
                connection.Close();

            return View();

        }
    }
}