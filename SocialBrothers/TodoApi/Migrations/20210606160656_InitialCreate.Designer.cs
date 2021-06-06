﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi.Models;

namespace TodoApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210606160656_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            HouseNumber = 35,
                            PostalCode = "3446BG",
                            Street = "Berlengakade"
                        },
                        new
                        {
                            Id = 2L,
                            City = "Schagen",
                            Country = "Netherlands",
                            HouseNumber = 189,
                            PostalCode = "1742EC",
                            Street = "Sperwerhof"
                        },
                        new
                        {
                            Id = 3L,
                            City = "Zoetermeer",
                            Country = "Netherlands",
                            HouseNumber = 92,
                            PostalCode = "2711AB",
                            Street = "Promenadeplein"
                        },
                        new
                        {
                            Id = 4L,
                            City = "Amsterdam",
                            Country = "Netherlands",
                            HouseNumber = 82,
                            PostalCode = "1021VG",
                            Street = "Kievitstraat"
                        },
                        new
                        {
                            Id = 5L,
                            City = "Maastricht",
                            Country = "Netherlands",
                            HouseNumber = 174,
                            PostalCode = "6228XV",
                            Street = "Bronckweg"
                        },
                        new
                        {
                            Id = 6L,
                            City = "Breda",
                            Country = "Netherlands",
                            HouseNumber = 134,
                            PostalCode = "4827AG",
                            Street = "Willem van Boelrestraat"
                        },
                        new
                        {
                            Id = 7L,
                            City = "Enkhuizen",
                            Country = "Netherlands",
                            HouseNumber = 133,
                            PostalCode = "1601JS",
                            Street = "Apenspel"
                        },
                        new
                        {
                            Id = 8L,
                            City = "Waterlandkerkje",
                            Country = "Netherlands",
                            HouseNumber = 106,
                            PostalCode = "4508PH",
                            Street = "Plaatweg"
                        },
                        new
                        {
                            Id = 9L,
                            City = "Oosterbeek",
                            Country = "Netherlands",
                            HouseNumber = 119,
                            PostalCode = "6861XZ",
                            Street = "Noorderweg"
                        },
                        new
                        {
                            Id = 10L,
                            City = "Meppel",
                            Country = "Netherlands",
                            HouseNumber = 17,
                            PostalCode = "7941CH",
                            Street = "Bloemendalstraat"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
