using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.booking
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Booking Booking { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == id), "Guest,RoomType,Room");

            if (Booking == null)
                return RedirectToAction("NotFound", "Error");
            return Page();
        }
    }
}
