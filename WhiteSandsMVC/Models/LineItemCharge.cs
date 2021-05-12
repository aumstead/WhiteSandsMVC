using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class LineItemCharge
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        [Column(TypeName= "money")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(BillOfSale))]
        public int BillOfSaleId { get; set; }
        public BillOfSale BillOfSale { get; set; }
    }
}
