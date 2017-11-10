using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContextDbContex : DbContext
    {
        public SalesContextDbContex()
        {
        }
        public SalesContextDbContex(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>(
                st =>
                {
                    st.Property(s => s.Name).HasColumnType("nvarchar(80)");
                });

            builder.Entity<Store>()
                .ToTable("Stores")
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store)
                .HasForeignKey(s => s.SoreId);

            builder.Entity<Product>(
                pr =>
                {
                    pr.Property(p => p.Name).HasColumnType("nvarchar(50)");
                });

            builder.Entity<Product>()
                .ToTable("Products")
                .HasMany(p => p.Sales)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.ProductId);

            builder.Entity<Customer>(
                cr =>
                {
                    cr.Property(c => c.Name).HasColumnType("nvarchar(100)");
                    cr.Property(c => c.Email).HasColumnType("varchar(80)");
                });

            builder.Entity<Customer>()
                .ToTable("Customers")
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);

            builder.Entity<Sale>()
                .ToTable("Sales");
        }
    }
}
