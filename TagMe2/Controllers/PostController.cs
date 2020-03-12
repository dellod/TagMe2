using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public String Add(Post Image)
        {

            return Image.Caption;

        }
    }
}