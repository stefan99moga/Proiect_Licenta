using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantSiteComenzi.Models;


namespace RestaurantSiteComenzi.Models
{
    public class RestaurantContext : IdentityDbContext<IdentityUser>
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
            
        }
        public DbSet<ComandaLivrare> Comanda_Livrare { get; set; }
        public DbSet<ComandaLivrareProdus> Comanda_Livrare_Produs { get; set; }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Livrator> Livrator { get; set; }
        public DbSet<Adrese> Adrese { get; set; }
        public DbSet<Categorie_Produs> Categorie_Produs { get; set; }
        public DbSet<Cos> Articol_Cos { get; set; }
    }
}
