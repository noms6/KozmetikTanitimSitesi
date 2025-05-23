using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using KozmetikTanitimSite.Models;

namespace KozmetikTanitimSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Sepet> Sepetler { get; set; } 

        // Diğer DbSet'ler...

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // İlişkileri tanımla
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
