using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TheRange.Core.Entity;
using TheRange.Core.Entity.Mens;

namespace TheRange.Infrastructure.SQL.Data
{
    public class TheRangeContext :DbContext
    {
        public DbSet<Sweatshirts> Sweatshirts { get; set; }
        public DbSet<Tops> Tops { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public  DbSet<Product> Products { get; set; }

        public TheRangeContext(DbContextOptions<TheRangeContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>() //one order has many umbrellas
                .HasMany(e => e.Products) //each umbrella has one order
                .WithOne(c => c.Order) // each umbrella has one order
                .OnDelete(DeleteBehavior.SetNull);

            /*modelBuilder.Entity<Order>() //one order has many umbrellas
                .HasMany(e => e.Tops) //each umbrella has one order
                .WithOne(c => c.Order) // each umbrella has one order
                .OnDelete(DeleteBehavior.SetNull);*/

            modelBuilder.Entity<Order>()
                .HasOne(e => e.Customers)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}