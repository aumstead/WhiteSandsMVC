using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;
using WhiteSandsMVC.ViewModels;

namespace WhiteSandsMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Bookings()
        //{
        //    return View();
        //}

        //[Route("/admin/booking/details/{id}")]
        //public async Task<IActionResult> BookingDetails(int id)
        //{
        //    var Booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == id), "Guest,RoomType,Room");
        //    return View("BookingDetails", Booking);
        //}

        //public IActionResult Guests()
        //{
        //    return View();
        //}

        //[HttpGet("{id}")]
        //[Route("/admin/booking/edit/guest/{id}")]
        //public async Task<IActionResult> EditGuestDetails(int id)
        //{
        //    var guest = await _unitOfWork.Guest.Get(id);
        //    return View(guest);
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditGuestDetails(Guest updatedGuest)
        //{
        //    var booking = await _unitOfWork.Booking.GetFirstOrDefault(b => b.GuestId == updatedGuest.Id);
        //    var guest = _unitOfWork.Guest.Update(updatedGuest);
        //    return RedirectToAction("BookingDetails", booking.Id);
        //}

        //[Route("/admin/booking/edit/payment/{id}")]
        //public async Task<IActionResult> EditPaymentDetails(int id)
        //{
        //    var guest = await _unitOfWork.Guest.Get(id);
            
        //    return View(guest);
        //}
    }
}
