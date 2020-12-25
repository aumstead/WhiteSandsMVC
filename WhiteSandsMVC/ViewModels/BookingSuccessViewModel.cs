using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;

namespace WhiteSandsMVC.ViewModels
{
    public class BookingSuccessViewModel
    {
        public Booking Booking { get; set; }
        public RoomType RoomType { get; set; }
        public Guest Guest { get; set; }

        // hacks to get past exception where model is null on form submit
        //public decimal RoomTypePrice { get; set; }
        //public string RoomTypeName { get; set; }
        //public string RoomTypeBeds { get; set; }
    }
}
