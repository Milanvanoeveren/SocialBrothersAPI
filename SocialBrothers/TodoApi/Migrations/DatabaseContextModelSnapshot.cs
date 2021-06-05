﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi.Models;

namespace TodoApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("TodoApi.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            City = "Utrecht",
                            Country = "Netherlands",
                            HouseNumber = 1,
                            PostalCode = "3446BG",
                            Street = "Berlengakade"
                        },
                        new
                        {
                            Id = 2L,
                            City = "Groningen",
                            Country = "Netherlands",
                            HouseNumber = 2,
                            PostalCode = "5461AB",
                            Street = "Straatweg"
                        },
                        new
                        {
                            Id = 3L,
                            City = "Rotterdam",
                            Country = "Netherlands",
                            HouseNumber = 3,
                            PostalCode = "5689FW",
                            Street = "Lange Weg"
                        },
                        new
                        {
                            Id = 4L,
                            City = "Amsterdam",
                            Country = "Netherlands",
                            HouseNumber = 4,
                            PostalCode = "1285GB",
                            Street = "Linschoterweg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}