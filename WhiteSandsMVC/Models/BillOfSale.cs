using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class BillOfSale
    {
        public int Id { get; set; }

        [Required]
        public string PaymentStatus { get; set; } = "Unpaid";
        [Required]
        public string PaymentMethod { get; set; } = "Credit/Debit Card";
    }
}
