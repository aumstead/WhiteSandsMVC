using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.ViewModels
{
    public class ChooseRoomViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Adults { get; set; }
        public string Children { get; set; }
        public string Promo { get; set; }
    }
}
