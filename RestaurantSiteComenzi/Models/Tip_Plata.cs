using System.ComponentModel.DataAnnotations;

namespace RestaurantSiteComenzi.Models
{
    public class Tip_Plata
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Tipul_Platii { get; set; } // 1=Card    2=Cash    3=Online
    }
}
