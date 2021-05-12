using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.Billing
{
    [Authorize(Roles = "Admin, Employee")]
    public class InvoiceModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int billOfSaleId)
        {
            var booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.BillOfSaleId == billOfSaleId), "Guest,BillOfSale");

            if (booking == null)
                return RedirectToAction("NotFound", "Error");

            var lineItems = await _unitOfWork.LineItemCharge.GetAll(item => item.BillOfSaleId == billOfSaleId);

            var billOfSale = await _unitOfWork.BillOfSale.Get(billOfSaleId);

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
                BillOfSale = billOfSale
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var billOfSaleObj = await _unitOfWork.BillOfSale.Get(Input.Booking.BillOfSaleId);
            billOfSaleObj.PaymentStatus = "Paid";
            _unitOfWork.BillOfSale.Update(billOfSaleObj);

            var booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.BillOfSaleId == Input.Booking.BillOfSaleId), "Guest,BillOfSale");

            if (booking == null)
                return RedirectToAction("NotFound", "Error");

            var lineItems = await _unitOfWork.LineItemCharge.GetAll(item => item.BillOfSaleId == Input.Booking.BillOfSaleId);

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
                BillOfSale = billOfSaleObj
            };
            return Page();
        }

        public class InputModel
        {
            public Booking Booking { get; set; }
            public IEnumerable<LineItemCharge> LineItemCharges { get; set; }
            public decimal TotalCost { get; set; }
            public BillOfSale BillOfSale { get; set; }
        }
    }
}
