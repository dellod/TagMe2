using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TagMe2.Controllers
{
    public class accountController : Controller
    {
        
        public IActionResult RegisterPage()
        {
            return View();

        }

        public IActionResult LoginPage()
        {

            return View();
        }
    }
}