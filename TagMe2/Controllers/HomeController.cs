using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TagMe2.Models;

namespace TagMe2.Controllers
{

    public class HomeController : Controller
    {

        public static SqlConnection connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database=DatabaseTagMe2;Trusted_Connection=True;MultipleActiveResultSets=true");

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            connection.Open();
            string commandText = "SELECT * FROM Post";
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
                postsFound.Add(new Post(a, url, null, null, row["text"].ToString(),5, null));
                i++;
            }
            connection.Close();
            return View("allimageView", postsFound);
            // this is just temporary change
            //return View("allimageView", null);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
