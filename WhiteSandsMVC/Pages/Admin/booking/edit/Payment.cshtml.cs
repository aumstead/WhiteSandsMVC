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

namespace WhiteSandsMVC.Pages.Admin.booking.edit
{
    [Authorize(Roles = "Admin, Employee")]
    public class PaymentModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int guestId, int bookingId)
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
                BookingId = bookingId
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var guestObj = await _unitOfWork.Guest.Get(Input.GuestId);

                guestObj.NameOnCreditCard = Input.NameOnCreditCard;
                guestObj.CreditCardNumber = Input.CreditCardNumber;
                guestObj.CreditCardExpiryMonth = Input.CreditCardExpiryMonth;
                guestObj.CreditCardExpiryYear = Input.CreditCardExpiryYear;

                _unitOfWork.Guest.Update(guestObj);

                return RedirectToPage("/Admin/Booking/details", new { id = Input.BookingId });
            }

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
            public int BookingId { get; set; }
        }
    }
}
