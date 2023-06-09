﻿using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Infrastucture.Configs
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.CategoryId).ValueGeneratedOnAdd();
                entity.Property(c => c.CategoryName).IsRequired();
                entity.Property(c => c.Description);
                entity.Property(c => c.Picture);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers");
                entity.HasKey(c => c.SupplierId);
                entity.Property(c => c.SupplierId).ValueGeneratedOnAdd();
                entity.Property(c => c.CompanyName).HasMaxLength(40).IsRequired();
                entity.Property(c => c.ContactName).HasMaxLength(30);
                entity.Property(c => c.ContactTitle).HasMaxLength(30);
                entity.Property(c => c.PostalCode).HasMaxLength(10);
                entity.Property(c => c.Country).HasMaxLength(15);
                entity.Property(c => c.City).HasMaxLength(15);
                entity.Property(c => c.Address).HasMaxLength(15);
                entity.Property(c => c.Fax).HasMaxLength(15).IsRequired(false);
                entity.Property(c => c.HomePage).IsRequired(false);
                entity.Property(c => c.Phone).HasMaxLength(24);
                entity.Property(c => c.Region).HasMaxLength(15).IsRequired(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.ProductId);
                entity.Property(c => c.ProductId).ValueGeneratedOnAdd();
                entity.Property(p => p.ProductName).IsRequired();
                entity.Property(p => p.UnitPrice);
                entity.Property(p => p.QuantityPerUnit);
                entity.Property(p => p.Discontinued).IsRequired();
                entity.Property(p => p.ReorderLevel);
                entity.Property(p => p.UnitsInStock);
                entity.Property(p => p.UnitsOnOrder);
                entity.Property(p => p.CategoryId);
                entity.Property(p => p.SupplierId);
                entity.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
                entity.HasOne(p => p.Supplier).WithMany(c => c.Products).HasForeignKey(p => p.SupplierId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}