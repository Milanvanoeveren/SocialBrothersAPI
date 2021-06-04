using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = SocialBrothers.db;");
        }

        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
            new Address() { Id = 1, HouseNumber = 1, Country = "Netherlands", City = "Utrecht", Street = "Berlengakade", PostalCode = "3446BG" },
            new Address() { Id = 2, HouseNumber = 2, Country = "Netherlands", City = "Groningen", Street = "Straatweg", PostalCode = "5461AB" },
            new Address() { Id = 3, HouseNumber = 3, Country = "Netherlands", City = "Rotterdam", Street = "Lange Weg", PostalCode = "5689FW" },
            new Address() { Id = 4, HouseNumber = 4, Country = "Netherlands", City = "Amsterdam", Street = "Linschoterweg", PostalCode = "1285GB" }
            );
        }
    }
}
