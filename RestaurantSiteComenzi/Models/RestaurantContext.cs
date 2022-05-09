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
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Livrator> Livrator { get; set; }
        public DbSet<Adrese> Adrese { get; set; }
        public DbSet<Categorie_Produs> Categorie_Produs { get; set; }
        public DbSet<Cos> Cos { get; set; }
        public DbSet<Comenzi> Comenzi { get; set; }
        public DbSet<Tip_Plata> Tip_Plata { get; set; }
        public DbSet<Stare_Comanda> Stare_Comanda { get; set; }
    }
}
