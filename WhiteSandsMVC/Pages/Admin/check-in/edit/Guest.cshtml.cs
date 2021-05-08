using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.check_in.edit
{
    [Authorize(Roles = "Admin, Employee")]
    public class GuestModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestModel(IUnitOfWork unitOfWork)
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
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                PhoneNumber = guest.PhoneNumber,
                Email = guest.Email,
                Country = guest.Country,
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

                guestObj.FirstName = Input.FirstName;
                guestObj.LastName = Input.LastName;
                guestObj.PhoneNumber = Input.PhoneNumber;
                guestObj.Email = Input.Email;
                guestObj.Country = Input.Country;

                _unitOfWork.Guest.Update(guestObj);

                return RedirectToPage("/Admin/check-in/StepOneVerifyStay", new { id = Input.BookingId });
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }
            [Required]
            public string Email { get; set; }
            [Display(Name = "Country")]
            public string Country { get; set; }
            public int GuestId { get; set; }
            public int BookingId { get; set; }
        }
    }
}