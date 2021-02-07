using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public string NameOnCreditCard { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardExpiryMonth { get; set; }
        public string CreditCardExpiryYear { get; set; }
        public bool SubscribedToEmailList { get; set; }
        public string MattressPreference { get; set; }
        public string PillowPreference { get; set; }
        public string SmokingPreference { get; set; }

    }
}
