using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebService.Models;
using System.Security.Claims;


namespace WebService.Data
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
        public DbSet<Adrese> Adrese { get; set; }
        public DbSet<Categorie_Produs> Categorie_Produs { get; set; }
        public DbSet<Cos> Articol_Cos { get; set; }
    }
}
