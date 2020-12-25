using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class CheckRatesViewModel
    {
        [Required]
        [Display(Name = "Check in")]
        public string CheckInDate { get; set; }

        [Required]
        [Display(Name ="Check out")]
        public string CheckOutDate { get; set; }

        [Required]
        [Range(1, 6)]
        public string Adults { get; set; }

        [Range(0, 6)]
        public string Children { get; set; }

        [MaxLength(5)]
        public string Promo { get; set; }
    }
}
