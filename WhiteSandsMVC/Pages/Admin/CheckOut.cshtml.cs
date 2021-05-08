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

        public async Task<IActionResult> OnGet(int billOfSaleId)
        {
            //var booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == bookingId), "Guest,RoomType,Room,BillOfSale");

            //if (booking == null)
            //    return RedirectToAction("NotFound", "Error");

            var lineItems = await _unitOfWork.LineItemCharge.GetAll(item => item.BillOfSaleId == billOfSaleId);

            var invoice = await _unitOfWork.BillOfSale.Get(billOfSaleId);

            decimal total = 0;
            foreach (var item in lineItems)
            {
                total += item.Amount;
            }

            Input = new InputModel()
            {
                //Booking = booking,
                LineItemCharges = lineItems,
                TotalCost = total,
                PaymentStatus = invoice.PaymentStatus
            };

            return Page();
        }

        public class InputModel
        {
            //public Booking Booking { get; set; }
            public IEnumerable<LineItemCharge> LineItemCharges { get; set; }
            public decimal TotalCost { get; set; }
            public string PaymentStatus { get; set; }
        }
    }
}
