using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.billing.edit
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
            var lineItems = await _unitOfWork.LineItemCharge.GetAll(item => item.BillOfSaleId == billOfSaleId);

            var invoice = await _unitOfWork.BillOfSale.Get(billOfSaleId);

            decimal total = 0;
            foreach (var item in lineItems)
            {
                total += item.Amount;
            }

            Input = new InputModel()
            {
                LineItemCharges = lineItems,
                TotalCost = total,
            };

            return Page();
        }

        public class InputModel
        {
            public IEnumerable<LineItemCharge> LineItemCharges { get; set; }
            public decimal TotalCost { get; set; }
            public string PaymentStatus { get; set; }
        }
    }
}
