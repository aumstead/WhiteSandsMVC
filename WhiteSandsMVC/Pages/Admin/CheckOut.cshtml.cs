using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin
{
    [Authorize(Roles = "Admin, Employee")]
    public class CheckOutModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckOutModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int bookingId)
        {
            var booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == bookingId), "Guest,Room,BillOfSale");

            if (booking == null)
                return RedirectToAction("NotFound", "Error");

            var invoice = await _unitOfWork.BillOfSale.Get(booking.BillOfSaleId);


            Input = new InputModel()
            {
                Booking = booking
            };

            return Page();
        }

        public async Task<IActionResult> OnPost(int bookingId)
        {
            //var bookingFromDb = await _unitOfWork.Booking.Get(bookingId);
            var bookingFromDb = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == bookingId), "Guest,Room,BillOfSale");
            if (bookingFromDb == null)
                return RedirectToAction("NotFound", "Error");
            bookingFromDb.Status = "Checked Out";
            _unitOfWork.Booking.Update(bookingFromDb);

            var invoice = await _unitOfWork.BillOfSale.Get(bookingFromDb.BillOfSaleId);

            Input = new InputModel()
            {
                Booking = bookingFromDb
            };

            return Page();
        }

        public class InputModel
        {
            public Booking Booking { get; set; }
        }
    }
}
