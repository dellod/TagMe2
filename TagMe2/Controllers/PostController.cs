using System;
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
                connection.Open();
                string commandText = "Insert into Post (UUID,text, image_url) VALUES(@Id,@tx,@url)";
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@tx", Image.Caption);

                string fileName = Path.GetFileNameWithoutExtension(Image.ImageFile.FileName);
                string extension = Path.GetExtension(Image.ImageFile.FileName);
                fileName += extension;
                Image.URL = fileName;

            cmd.Parameters.AddWithValue("@url", Image.URL);

            Console.WriteLine(Image.URL);

              
                cmd.ExecuteNonQuery();
                connection.Close();

            return View();

        }

        public IActionResult commentDisplay()
        {
            Guid i = Guid.NewGuid();
            Profile prof = new Profile(null, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Sant%27Angelo_bridge%2C_dusk%2C_Rome%2C_Italy.jpg/1199px-Sant%27Angelo_bridge%2C_dusk%2C_Rome%2C_Italy.jpg", null);
            User user = new User(i, "yossri", "yossri", "khalil", prof);
            Address location = new Address("calgary","canada","AB",1.0,1.0);
            Post temp = new Post(i, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Sant%27Angelo_bridge%2C_dusk%2C_Rome%2C_Italy.jpg/1199px-Sant%27Angelo_bridge%2C_dusk%2C_Rome%2C_Italy.jpg", location, user, "hell ya", 5, null);


            return View(temp);
        }
    }
}