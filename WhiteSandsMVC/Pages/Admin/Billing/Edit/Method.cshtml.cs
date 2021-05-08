using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.Billing.Edit
{
    [Authorize(Roles = "Admin, Employee")]
    public class MethodModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public MethodModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int billOfSaleId)
        {
            var billOfSale = await _unitOfWork.BillOfSale.Get(billOfSaleId);

            Input = new InputModel
            {
                PaymentMethod = billOfSale.PaymentMethod,
                BillOfSaleId = billOfSale.Id
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var billOfSale = await _unitOfWork.BillOfSale.Get(Input.BillOfSaleId);
            billOfSale.PaymentMethod = Input.PaymentMethod;
            _unitOfWork.BillOfSale.Update(billOfSale);
            return RedirectToPage("/Admin/Billing/Invoice", new { Input.BillOfSaleId });
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Payment Method")]
            public string PaymentMethod { get; set; }
            public int BillOfSaleId { get; set; }
        }
    }
}
