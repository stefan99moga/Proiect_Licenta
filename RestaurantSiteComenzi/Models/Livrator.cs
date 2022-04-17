using System.ComponentModel.DataAnnotations;

namespace RestaurantSiteComenzi.Models
{
    public class Livrator
    {
        [Key]
        public int id { get; set; }
        [Required, Display(Name ="Nume:")]
        public string Nume_Livrator { get; set; }
        [Required, Display(Name = "Prenume:")]
        public string Prenume_Livrator { get; set; }
        [Required, Display(Name = "Telefon:")]
        public string Telefon_Livrator { get; set; }
        [Required, Display(Name = "Statut angajat:")]
        public bool Statut_Livrator { get; set; }



    }
}
