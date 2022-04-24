using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSiteComenzi.Models
{
    public class ComandaLivrare
    {
        [Key, Display(Name = "Nr comanda:")]
        public int id { get; set; }
        
        [Required, Display(Name = "Nume:")]
        public string Nume { get; set; }
        
        [Required, Display(Name = "Prenume")]
        public string Prenume { get; set; }
        
        [Required, Display(Name = "Oras")]
        public string Oras { get; set; }
        
        [Required, Display(Name = "Strada")]
        public string Strada { get; set; }
        
        [Required, Display(Name = "Numar")]
        public string Numar { get; set; }
        
        [Display(Name = "Bloc")]
        public string Bloc { get; set; }
        
        [Display(Name = "Scara")]
        public string Scara { get; set; }
        
        [Display(Name = "Apartament")]
        public string Apartament { get; set; }
        
        [Required, Display(Name = "Telefon"), DataType(DataType.PhoneNumber)]
        public string Numar_Telefon { get; set; }

        [Display(Name = "Data Comanda")]
        public DateTime Data_Comanda { get; set; } = DateTime.Now;

        [ForeignKey("Stare_Comanda_ID")]
        public Stare_Comanda Stare_Comanda { get; set; }

        [Required, Display(Name = "Stare Comanda"), Range(1,5)]
        public int Stare_Comanda_ID { get; set; }
    }
}
