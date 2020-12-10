using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Controllers
{
    public class AccomodationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
