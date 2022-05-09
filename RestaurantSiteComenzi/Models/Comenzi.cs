using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSiteComenzi.Models
{
    public class Comenzi
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string User_ID { get; set; }
        //[Required]
        //public int Articol_Cos_ID { get; set; } // DB: Articol_cos  Model: Cos
        [Required]
        public int Adress_ID { get; set; } // DB: Adress    Model: Adrese
        [Required]
        public int Tip_Plata_ID { get; set; } // Tip_Plata
        [Required]
        [Display(Name = "Total Plată")]
        public decimal Total_Plata { get; set; }
        public string Total_Plata_Str { get { return String.Format("{0:0.00} lei", this.Total_Plata); } }

        [Display(Name = "Data")]
        [Required]
        public DateTime Data_Comanda { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Status curent comandă:")]
        public int Stare_Comanda_ID { get; set; } // Stare_Comanda

        public bool Is_Deprecated { get; set; }

        //foreign keys:
        //[ForeignKey("Articol_Cos_ID")]
        //public Cos Cos { get; set; }

        [ForeignKey("Adress_ID")]
        public Adrese Adrese { get; set; }

        [Display(Name = "Tipul plății")]
        [ForeignKey("Tip_Plata_ID")]
        public Tip_Plata Tip_plata { get; set; }

        [Display(Name = "Status Comanda")]
        [ForeignKey("Stare_Comanda_ID")]
        public Stare_Comanda Stare_Comanda { get; set; }
    }
}
