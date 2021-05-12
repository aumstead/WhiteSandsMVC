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
                PaymentStatus = invoice.PaymentStatus,
                LineItemCharges = lineItems.ToList(),
                TotalCost = total,
                BillOfSaleId = billOfSaleId
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var lineItemsFromDb = await _unitOfWork.LineItemCharge.GetAll(item => item.BillOfSaleId == Input.BillOfSaleId);

            var lineItemList = lineItemsFromDb.ToList();

            var billOfSaleFromDb = await _unitOfWork.BillOfSale.Get(Input.BillOfSaleId);

            if (lineItemList.Count == 0)
            {
                // user removed all charges
                return RedirectToPage("/Admin/Billing/Invoice", new { billOfSaleId = Input.BillOfSaleId });
            }

            for (int i = 0; i < Input.LineItemCharges.Count; i++)
            {
                lineItemList[i].Amount = Input.LineItemCharges[i].Amount;
                lineItemList[i].Name = Input.LineItemCharges[i].Name;
                _unitOfWork.LineItemCharge.Update(lineItemList[i]);
            }

            billOfSaleFromDb.PaymentStatus = Input.PaymentStatus;

            _unitOfWork.BillOfSale.Update(billOfSaleFromDb);
            
            return RedirectToPage("/Admin/Billing/Invoice", new { billOfSaleId = Input.BillOfSaleId });
        }

        public class InputModel
        {
            public List<LineItemCharge> LineItemCharges { get; set; }
            public decimal TotalCost { get; set; }

            [Required]
            [Display(Name = "Payment Status")]
            public string PaymentStatus { get; set; }
            public int BillOfSaleId { get; set; }
        }
    }
}
