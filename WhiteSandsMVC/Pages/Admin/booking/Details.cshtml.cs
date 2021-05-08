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

namespace WhiteSandsMVC.Pages.Admin.booking
{
    [Authorize(Roles = "Admin, Employee")]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var Booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == id), "Guest,RoomType,Room,BillOfSale");

            if (Booking == null)
                return RedirectToAction("NotFound", "Error");

            var lineItems = await _unitOfWork.LineItemCharge.GetAll(item => item.BillOfSaleId == Booking.BillOfSaleId);

            decimal total = 0;
            foreach (var item in lineItems)
            {
                total += item.Amount;
            }

            Input = new InputModel()
            {
                Booking = Booking,
                LineItemCharges = lineItems,
                TotalCost = total
            };

            return Page();
        }

        public class InputModel
        {
            public Booking Booking { get; set; }
            public IEnumerable<LineItemCharge> LineItemCharges { get; set; }
            public decimal TotalCost { get; set; }
        }
    }
}
