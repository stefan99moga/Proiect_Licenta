using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TaskAlocModel
{
    public partial class TaskAlocEntitiesModel : DbContext
    {
        public TaskAlocEntitiesModel()
            : base("name=TaskAlocEntitiesModel")
        {
        }

        public virtual DbSet<Chef> Chefs { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chef>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Chef)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Pizza)
                .WillCascadeOnDelete();
        }
    }
}
