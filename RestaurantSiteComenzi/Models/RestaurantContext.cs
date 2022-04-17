using Microsoft.EntityFrameworkCore;


namespace RestaurantSiteComenzi.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
            
        }
        public DbSet<ComandaLivrare> Comanda_Livrare { get; set; }
        public DbSet<ComandaLivrareProdus> Comanda_Livrare_Produs { get; set; }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Livrator> Livrator { get; set; }
    }
}
