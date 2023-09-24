﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp.Data;

#nullable disable

namespace WeatherApp.Migrations
{
    [DbContext(typeof(WeatherAppDbContext))]
    partial class WeatherAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WeatherApp.Models.CityLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Latitude")
                        .HasColumnType("float");

                    b.Property<float>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CityLocation");
                });

            modelBuilder.Entity("WeatherApp.Models.WeatherData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Humidity")
                        .HasColumnType("float");

                    b.Property<float>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeRecorded")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("WeatherData");
                });
#pragma warning restore 612, 618
        }
    }
}
