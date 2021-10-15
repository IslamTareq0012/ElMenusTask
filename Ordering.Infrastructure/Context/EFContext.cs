using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Order.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Context
{
    public class EFContext : DbContext
    {
        public EFContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RJ8LH3D;Database=Elmenus;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defing Joining Entity Primary Keys
            modelBuilder.Entity<OrderItemToOrder>().HasKey(sc => new { sc.OrderID, sc.OrderItemID });


            //Configure Many-TO-Many relationship manually
            modelBuilder.Entity<OrderItemToOrder>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.OrderItemToOrders)
                .HasForeignKey(sc => sc.OrderID);


            modelBuilder.Entity<OrderItemToOrder>()
                .HasOne<OrderItem>(sc => sc.OrderItem)
                .WithMany(s => s.OrderItemToOrders)
                .HasForeignKey(sc => sc.OrderItemID);

        }

        //Entities

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemToOrder> OrderItemToOrders { get; set; }
    }
}
