using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class UserTravelInterest
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        public int TravelInterestId { get; set; }

        [ForeignKey("TravelInterestId")]
        public TravelInterest Interest { get; set; }
    }
}
