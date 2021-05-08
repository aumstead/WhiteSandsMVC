using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;
using WhiteSandsMVC.Utility;

namespace WhiteSandsMVC.Pages.Admin.check_in
{
    [Authorize(Roles = "Admin, Employee")]
    public class StepTwoBillingModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public StepTwoBillingModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int bookingId)
        {
            var booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == bookingId), "Guest,RoomType,Room,BillOfSale");

            if (booking == null)
                return RedirectToAction("NotFound", "Error");

            var lineItems = await _unitOfWork.LineItemCharge.GetAll(item => item.BillOfSaleId == booking.BillOfSaleId);

            var invoice = await _unitOfWork.BillOfSale.Get(booking.BillOfSaleId);

            decimal total = 0;
            foreach (var item in lineItems)
            {
                total += item.Amount;
            }

            Input = new InputModel()
            {
                Booking = booking,
                LineItemCharges = lineItems,
                TotalCost = total,
                PaymentStatus = invoice.PaymentStatus
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var bookingObj = await _unitOfWork.Booking.Get(Input.Booking.Id);
            //var roomObj = await _unitOfWork.Room.Get(bookingObj.RoomId);

            bookingObj.Status = BookingStatus.CheckedIn;
            //roomObj.Available = false;
            _unitOfWork.Booking.Update(bookingObj);
            //_unitOfWork.Room.Update(roomObj);
            return RedirectToPage("/admin/arrivals");           
        }

        public class InputModel
        {
            public Booking Booking { get; set; }
            public IEnumerable<LineItemCharge> LineItemCharges { get; set; }
            public decimal TotalCost { get; set; }
            public string PaymentStatus { get; set; }
        }
    }
}
