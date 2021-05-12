using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.Billing.Edit
{
    [Authorize(Roles = "Admin, Employee")]
    public class AddChargeModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddChargeModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet(int billOfSaleId)
        {
            Input = new InputModel
            {
                BillOfSaleId = billOfSaleId
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Input.LineItemCharge.BillOfSaleId = Input.BillOfSaleId;
            await _unitOfWork.LineItemCharge.Add(Input.LineItemCharge);
            _unitOfWork.Save();
            return RedirectToPage("/Admin/Billing/Invoice", new { billofSaleId = Input.BillOfSaleId });
        }

        public class InputModel
        {
            public LineItemCharge LineItemCharge { get; set; }
            public int BillOfSaleId { get; set; }
        }
    }
}
