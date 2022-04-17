using System.ComponentModel.DataAnnotations;

namespace RestaurantSiteComenzi.Views
{
    public class RestaurantViewModel
    {
        [Key]
        public int Id { get; set; }
        public int Produs { get; set; }
        public int Comanda { get; set; }
        public int Cantitate { get; set; } 

    }
}
