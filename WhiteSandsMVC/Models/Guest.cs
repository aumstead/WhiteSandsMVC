using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Cannot exceed 50 characters.")]
        [Display(Name ="first name")]
        public string FirstName { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Cannot exceed 50 characters.")]
        [Display(Name = "last name")]
        public string LastName { get; set; }
    
        [NotMapped]
        public string FullName { get { return FirstName + ' ' + LastName; } }

        [Required, MaxLength(50, ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "mobile number")]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress, RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "A valid email is required"), MaxLength(50, ErrorMessage = "Please use an email with fewer than 50 characters.")]
        [Display(Name = "email")]
        public string Email { get; set; }

        [Required, EmailAddress]
        [Compare("Email", ErrorMessage = "Email addresses must match."), Display(Name = "confirm email")]
        public string ConfirmEmail { get; set; }

        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Country { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        [Display(Name = "name on credit card")]
        public string NameOnCreditCard { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        [Display(Name = "credit card number")]
        public string CreditCardNumber { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Select a valid month")]
        [Display(Name = "expiration month")]
        public string CreditCardExpiryMonth { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Select a valid year")]
        [Display(Name = "expiration year")]
        public string CreditCardExpiryYear { get; set; }

        public bool SubscribedToEmailList { get; set; }

    }
}
