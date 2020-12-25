using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class RoomType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required, MaxLength(300, ErrorMessage = "Cannot exceed 300 characters.")]
        public string Name { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string RoomSize { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string Beds { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string Occupancy { get; set; }

        [Required]
        public byte MaxAdultCapacity { get; set; }

        [Required]
        public byte MaxChildCapacity { get; set; }

        [MaxLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string ExtraBeds { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string Location { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string Bathroom { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Filename cannot exceed 100 characters.")]
        public string PhotoPath { get; set; }
    }
}
