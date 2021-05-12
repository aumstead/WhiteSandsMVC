using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("Occupied")]
        public async Task<IActionResult> GetOccupied()
        {
            return Json(new { data = await _unitOfWork.Room.GetAll((room => room.Available == false), null, "RoomType") });
        }

        [HttpGet("Available")]
        public async Task<IActionResult> GetAvailable()
        {
            return Json(new { data = await _unitOfWork.Room.GetAll((room => room.Available == true), null, "RoomType") });
        }

        //[HttpGet("arrivals")]
        //public async Task<IActionResult> Arrivals()
        //{
        //    var Today = DateTime.Today;
        //    return Json(new { data = await _unitOfWork.Booking.GetAll((booking => booking.CheckInDate == Today), null, "Guest") });
        //}

        //[HttpGet("departures")]
        //public async Task<IActionResult> Departures()
        //{
        //    var Today = DateTime.Today;
        //    return Json(new { data = await _unitOfWork.Booking.GetAll((booking => booking.CheckOutDate == Today), null, "Guest,BillOfSale") });
        //}

        //[HttpGet("inhouse")]
        //public async Task<IActionResult> InHouse()
        //{
        //    return Json(new { data = await _unitOfWork.Booking.GetAll((booking => booking.Status == "Checked In"), null, "Guest") });
        //}

    }
}
