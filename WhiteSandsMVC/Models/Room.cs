using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Room numbers do not have more than 10 characters.")]
        public string RoomNumber { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string View { get; set; }

        [Required]
        public bool Available { get; set; } = true;
    }
}
