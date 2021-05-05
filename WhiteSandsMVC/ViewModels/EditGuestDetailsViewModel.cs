using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;

namespace WhiteSandsMVC.ViewModels
{
    public class EditGuestDetailsViewModel
    {
        public Guest Guest { get; set; }
        public int BookingId { get; set; }
    }
}
