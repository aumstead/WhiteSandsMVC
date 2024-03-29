﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int GuestId { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }

        [Required]
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }

        public int BillOfSaleId { get; set; }
        [ForeignKey("BillOfSaleId")]
        public BillOfSale BillOfSale { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [NotMapped]
        public int Nights { get
            {
                TimeSpan nights;
                nights = CheckOutDate - CheckInDate;
                return nights.Days;
            }
        }

        [Required]
        public byte Adults { get; set; }

        [Required]
        public byte Children { get; set; }

        public string Status { get; set; }
        public string Notes { get; set; }

        public string Promo { get; set; }
    }
}
