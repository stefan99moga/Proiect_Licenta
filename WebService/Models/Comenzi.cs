using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    public class Comenzi
    {
        [Key]
        public int Id { get; set; }

        public string User_ID { get; set; }

        //public int Articol_Cos_ID { get; set; } // DB: Articol_cos  Model: Cos

        public int Adress_ID { get; set; } // DB: Adress    Model: Adrese

        public int Tip_Plata_ID { get; set; } // Tip_Plata

        [Display(Name = "Total Plată")]
        public decimal Total_Plata { get; set; }

        [Display(Name = "Data")]
        public DateTime Data_Comanda { get; set; } = DateTime.Now;

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

        [Display(Name = "Status")]
        [ForeignKey("Stare_Comanda_ID")]
        public Stare_Comanda Stare_Comanda { get; set; }
    }
}
