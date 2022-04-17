using System.ComponentModel.DataAnnotations;

namespace RestaurantSiteComenzi.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Nume produs:")]
        public string Nume_Produs { get; set; }
        [Required, Display(Name = "Pret produs:")]
        public Decimal Pret_Produs { get; set; }
        [Required, Display(Name = "Imagine:"), DataType(DataType.ImageUrl)]
        public string Imagine { get; set; }
    }
}
