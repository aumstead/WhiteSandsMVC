using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class CheckRatesViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public byte Adults { get; set; }
        public byte Children { get; set; }
        public string Promo { get; set; }
    }
}
