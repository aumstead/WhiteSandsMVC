using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class BillOfSale
    {
        public int Id { get; set; }
        public IEnumerable<LineItemCharge> LineItemCharges { get; set; }

        [NotMapped]
        public decimal TotalCost
        {
            get
            {
                decimal total = 0;
                foreach (var item in LineItemCharges)
                {
                    total += item.Amount;
                }
                return total;
            }
        }

        //[ForeignKey(nameof(Booking))]
        //public int BookingId { get; set; }
        //public Booking Booking { get; set; }
    }
}
