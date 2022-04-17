using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSiteComenzi.Models
{
    public class ComandaLivrareProdus
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Produs")]
        public int Produs_ID { get; set; }
        [Display(Name = "Comanda")]
        public int Comanda_ID { get; set; }
        [Display(Name ="Cantitate")]
        public int Cantitate { get; set; }
        [ForeignKey("Produs_ID")]
        public Produs produs { get; set; }
        [ForeignKey("Comanda_ID")]
        public ComandaLivrare comandaLivrare { get; set; }

    }
}
