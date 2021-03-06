﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioDotNet.Models;
using PortfolioDotnet.Controllers;


namespace PortfolioDotNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Projects()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


			public IActionResult Error()
        {
            return View();
        }
    }
}
