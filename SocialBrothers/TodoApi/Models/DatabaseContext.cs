using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = SocialBrothers.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
            new Address() { Id = 1, Street = "Berlengakade", HouseNumber = 35, PostalCode = "3446BG", City = "Utrecht", Country = "Netherlands" },
            new Address() { Id = 2, Street = "Sperwerhof", HouseNumber = 189, PostalCode = "1742EC", City = "Schagen", Country = "Netherlands" },
            new Address() { Id = 3, Street = "Promenadeplein", HouseNumber = 92, PostalCode = "2711AB", City = "Zoetermeer", Country = "Netherlands" },
            new Address() { Id = 4, Street = "Kievitstraat", HouseNumber = 82, PostalCode = "1021VG", City = "Amsterdam", Country = "Netherlands" },
            new Address() { Id = 5, Street = "Bronckweg", HouseNumber = 174, PostalCode = "6228XV", City = "Maastricht", Country = "Netherlands" },
            new Address() { Id = 6, Street = "Willem van Boelrestraat", HouseNumber = 134, PostalCode = "4827AG", City = "Breda", Country = "Netherlands" },
            new Address() { Id = 7, Street = "Apenspel", HouseNumber = 133, PostalCode = "1601JS", City = "Enkhuizen", Country = "Netherlands" },
            new Address() { Id = 8, Street = "Plaatweg", HouseNumber = 106, PostalCode = "4508PH", City = "Waterlandkerkje", Country = "Netherlands" },
            new Address() { Id = 9, Street = "Noorderweg", HouseNumber = 119, PostalCode = "6861XZ", City = "Oosterbeek", Country = "Netherlands" },
            new Address() { Id = 10, Street = "Bloemendalstraat", HouseNumber = 17, PostalCode = "7941CH", City = "Meppel", Country = "Netherlands" }
            );
        }
    }
}
