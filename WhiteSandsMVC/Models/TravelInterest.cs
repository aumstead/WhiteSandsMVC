using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class TravelInterest
    {
        public int Id { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string Name { get; set; }
    }
}
