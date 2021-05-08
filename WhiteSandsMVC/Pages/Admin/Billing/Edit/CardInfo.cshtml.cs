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
    public class CardInfoModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardInfoModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int guestId, int billOfSaleId)
        {
            var guest = await _unitOfWork.Guest.Get(guestId);
            if (guest == null)
                return RedirectToAction("NotFound", "Error");

            Input = new InputModel
            {
                NameOnCreditCard = guest.NameOnCreditCard,
                CreditCardNumber = guest.CreditCardNumber,
                CreditCardExpiryMonth = guest.CreditCardExpiryMonth,
                CreditCardExpiryYear = guest.CreditCardExpiryYear,
                GuestId = guest.Id,
                BillOfSaleId = billOfSaleId
            };

            return Page();
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Cardholder Name")]
            public string NameOnCreditCard { get; set; }
            [Required]
            [Display(Name = "Credit Card Number")]
            public string CreditCardNumber { get; set; }
            [Required]
            [Display(Name = "Month of Expiration")]
            public string CreditCardExpiryMonth { get; set; }
            [Required]
            [Display(Name = "Year of Expiration")]
            public string CreditCardExpiryYear { get; set; }
            public int GuestId { get; set; }
            public int BillOfSaleId { get; set; }
        }
    }
}
