﻿// <auto-generated />
using System;
using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportManagement.Data.Migrations
{
    [DbContext(typeof(All))]
    partial class AllModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirportManagement.Data.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LocationId");

                    b.Property<int?>("WeatherId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("WeatherId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AirportManagement.Data.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocalTimeZoneName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("AirportManagement.Data.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("AirportManagement.Data.Airport", b =>
                {
                    b.HasOne("AirportManagement.Data.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("AirportManagement.Data.Weather", "Weather")
                        .WithMany()
                        .HasForeignKey("WeatherId");
                });
#pragma warning restore 612, 618
        }
    }
}
