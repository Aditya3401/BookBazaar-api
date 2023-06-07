using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookBaazar.Infrastructure
{
    public class BookBazaarDbContext : DbContext
    {
        public BookBazaarDbContext(DbContextOptions<BookBazaarDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserID);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookID);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryID);
            });
            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => e.CartID);

            });
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderID);

            });
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemID);

            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
