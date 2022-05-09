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
