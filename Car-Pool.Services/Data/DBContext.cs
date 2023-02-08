using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Pool.Models;
using Car_Pool.Models.Bookings;
using Car_Pool.Models.User;
using Car_Pool.Models.Available_Rides;

namespace Car_Pool.Services.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<AvailableRides> AvailableRides { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableRides>().ToTable("Available_Rides");
            modelBuilder.Entity<Bookings>().ToTable("Bookings");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
