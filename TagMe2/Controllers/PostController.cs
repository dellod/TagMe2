﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TagMe2.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}