using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSiteComenzi.Models
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
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public int Produs_id { get; set; }
        public int? Comanda_id { get; set; }

        [Required]
        public bool Is_Cart_In_Order { get; set; }

        [ForeignKey("Produs_id")]
        public Produs Produs { get; set; }

        [ForeignKey("Comanda_id")]
        public Comenzi Comenzi { get; set; }
    }
}
