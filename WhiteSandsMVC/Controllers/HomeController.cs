using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;

namespace WhiteSandsMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/accomodations")]
        public IActionResult Accomodations()
        {
            return View();
        }

        [Route("/media")]
        public IActionResult Media()
        {
            return View();
        }

        [Route("/amenities")]
        public IActionResult Amenities()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CheckRatesViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ChooseRoom", "Reservations", new 
                {
                    checkInDate = model.CheckInDate,
                    checkOutDate = model.CheckOutDate,
                    adults = model.Adults,
                    children = model.Children,
                    promo = model.Promo
                });
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
