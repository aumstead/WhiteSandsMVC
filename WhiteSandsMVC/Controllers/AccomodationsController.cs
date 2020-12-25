using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;

namespace WhiteSandsMVC.Controllers
{
    public class AccomodationsController : Controller
    {
        public IActionResult Index()
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
    }
}
