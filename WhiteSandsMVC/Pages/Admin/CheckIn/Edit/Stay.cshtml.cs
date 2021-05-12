using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.check_in.edit
{
    [Authorize(Roles = "Admin, Employee")]
    public class StayModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public StayModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int bookingId)
        {
            var booking = await _unitOfWork.Booking.Get(bookingId);
            if (booking == null)
                return RedirectToAction("NotFound", "Error");

            Input = new InputModel
            {
                CheckIn = booking.CheckInDate.ToShortDateString(),
                CheckOut = booking.CheckOutDate.ToShortDateString(),                
                BookingId = bookingId
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookingObj = await _unitOfWork.Booking.Get(Input.BookingId);

                DateTime checkIn;
                DateTime checkOut;
                var isParsableCheckInDate = DateTime.TryParse(Input.CheckIn, out checkIn);
                var isParsableCheckOutDate = DateTime.TryParse(Input.CheckOut, out checkOut);

                bookingObj.CheckInDate = checkIn;
                bookingObj.CheckOutDate = checkOut;
                

                _unitOfWork.Booking.Update(bookingObj);

                return RedirectToPage("/admin/check-in/StepOneVerifyStay", new { id = Input.BookingId });
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Check In")]
            public string CheckIn { get; set; }

            [Required]
            [Display(Name = "Check Out")]
            public string CheckOut { get; set; }
            public int BookingId { get; set; }
        }
    }
}
