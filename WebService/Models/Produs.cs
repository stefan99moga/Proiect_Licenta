using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace WebService.Models
{
    public class Produs
    {
        [Key]
        public int id { get; set; }

        [Required, Display(Name = "Nume produs:")]
        public string Nume_Produs { get; set; }

        [Range(1, 1000)]
        [Required, Display(Name = "Pret produs:")]
        public decimal Pret_Produs { get; set; } 

        [Display(Name = "Imagine:"), DataType(DataType.ImageUrl)]
        public string Imagine { get; set; }

        [Required, Display(Name = "Categorie:"), Range(1,3)]
        public int Categorie_Id { get; set; } // 1-Pizza, 2-Desert, 3-Bauturi

        [ForeignKey("Categorie_Id")]
        public Categorie_Produs Categorie_produs { get; set; }
    }

}
