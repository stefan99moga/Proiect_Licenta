using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    public class Cos
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string User_id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public System.DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public int Produs_id { get; set; }

        [ForeignKey("Produs_id")]
        public Produs Produs { get; set; }
    }
}
