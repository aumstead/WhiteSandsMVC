using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Validators;

namespace WhiteSandsMVC.ViewModels
{
    public class ConfirmStayViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public byte Adults { get; set; }
        public byte Children { get; set; }
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public int Nights { get; set; }
        public DateTime CancellationDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Promo { get; set; }
        public Room Room { get; set; }
        public RoomType RoomType { get; set; }

        // form properties       

        [MustBeTrue(ErrorMessage = "You must accept the terms and conditions.")]
        public bool AcceptTermsAndConditions { get; set; }

        public Guest Guest { get; set; }
    }
}
