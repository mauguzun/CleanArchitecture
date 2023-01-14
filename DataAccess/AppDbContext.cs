using DataAccess.Interfaces;
using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Mssql
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public Task<int> SaveChagesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderItem>().HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product {Id = 1, Name = "Product 1", Price = 1.00M , Weight  =1},
                new Product {Id = 2, Name = "Product 2", Price = 10M , Weight  =10},
                new Product {Id = 3, Name = "Product 3", Price = 100M, Weight  =100},
            });

            modelBuilder.Entity<Order>().HasData(new List<Order>
            {
                new Order {Id = 1, Status = OrderStatus.Created, CreateDate = new DateTime(2020, 11, 01)}
            });

            modelBuilder.Entity<OrderItem>().HasData(new List<OrderItem>
            {
                new OrderItem {OrderId = 1, ProductId = 1, Quantity = 1},
                new OrderItem {OrderId = 1, ProductId = 2, Quantity = 2},
            });
        }
    }
}
