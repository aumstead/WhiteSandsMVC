using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.check_in
{
    [Authorize(Roles = "Admin, Employee")]
    public class StepOneVerifyStayModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public StepOneVerifyStayModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var Booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == id), "Guest,RoomType,Room");

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
