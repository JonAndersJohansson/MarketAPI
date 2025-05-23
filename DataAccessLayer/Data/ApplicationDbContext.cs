﻿using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ad>()
                .Property(a => a.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bid>()
                .Property(b => b.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Ad)
                .WithMany(a => a.Bids)
                .HasForeignKey(b => b.AdId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
