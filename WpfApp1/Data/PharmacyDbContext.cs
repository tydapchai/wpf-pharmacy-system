using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;
using System;
using System.Collections.Generic;

namespace WpfApp1.Data
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(local); database=PharmacyDB; uid=sa; pwd=1234567890; TrustServerCertificate=True; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Account)
                .WithMany(a => a.CartItems)
                .HasForeignKey(ci => ci.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Account)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed admin account
            var adminAccount = new Account
            {
                Id = 1,
                Username = "admin",
                Password = "admin123", // In real app, this should be hashed
                Email = "admin@pharmacy.com",
                Role = "Admin",
                Balance = 10000,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            modelBuilder.Entity<Account>().HasData(adminAccount);

            // Seed sample products
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Paracetamol 500mg",
                    Description = "Pain reliever and fever reducer",
                    Price = 5.99m,
                    StockQuantity = 100,
                    Category = "Pain Relief",
                    Manufacturer = "Generic Pharma",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    ImageUrl = "images/paracetamol.png"
                },
                new Product
                {
                    Id = 2,
                    Name = "Ibuprofen 400mg",
                    Description = "Anti-inflammatory pain reliever",
                    Price = 7.99m,
                    StockQuantity = 75,
                    Category = "Pain Relief",
                    Manufacturer = "HealthCare Inc",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    ImageUrl = "images/ibuprofen.png"
                },
                new Product
                {
                    Id = 3,
                    Name = "Vitamin C 1000mg",
                    Description = "Immune system support",
                    Price = 12.99m,
                    StockQuantity = 50,
                    Category = "Vitamins",
                    Manufacturer = "NutriLife",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    ImageUrl = "images/vitaminc.png"
                },
                new Product
                {
                    Id = 4,
                    Name = "Omeprazole 20mg",
                    Description = "Acid reflux medication",
                    Price = 15.99m,
                    StockQuantity = 30,
                    Category = "Digestive Health",
                    Manufacturer = "DigestCare",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    ImageUrl = "images/omeprazole.png"
                }
            };

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
} 