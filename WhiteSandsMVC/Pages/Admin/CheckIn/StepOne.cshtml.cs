using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.CheckIn
{
    [Authorize(Roles = "Admin, Employee")]
    public class StepOneModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public StepOneModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int bookingId)
        {
            var Booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == bookingId), "Guest,RoomType,Room");

            if (Booking == null)
                return RedirectToAction("NotFound", "Error");

            

            Input = new InputModel()
            {
                Booking = Booking
            };

            return Page();
        }

        public class InputModel
        {
            public Booking Booking { get; set; }
        }
    }
}
