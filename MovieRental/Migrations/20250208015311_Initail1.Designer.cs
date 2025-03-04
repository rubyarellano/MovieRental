﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieRental.Data;

#nullable disable

namespace MovieRental.Migrations
{
    [DbContext(typeof(MovieRentalDbContext))]
    [Migration("20250208015311_Initail1")]
    partial class Initail1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieRental.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("MovieRental.Models.RentalDetail", b =>
                {
                    b.Property<int>("RentalDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalDetailId"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("RentalHeaderId")
                        .HasColumnType("int");

                    b.HasKey("RentalDetailId");

                    b.HasIndex("MovieId");

                    b.HasIndex("RentalHeaderId");

                    b.ToTable("RentalDetails");
                });

            modelBuilder.Entity("MovieRental.Models.RentalHeader", b =>
                {
                    b.Property<int>("RentalHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalHeaderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RentalHeaderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("RentalHeader");
                });

            modelBuilder.Entity("MovieShopRental.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieRental.Models.RentalDetail", b =>
                {
                    b.HasOne("MovieShopRental.Models.Movie", "Movies")
                        .WithMany("RentalDetails")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieRental.Models.RentalHeader", "RentalHeader")
                        .WithMany("RentalDetails")
                        .HasForeignKey("RentalHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");

                    b.Navigation("RentalHeader");
                });

            modelBuilder.Entity("MovieRental.Models.RentalHeader", b =>
                {
                    b.HasOne("MovieRental.Models.Customers", "Customer")
                        .WithMany("RentalHeader")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MovieRental.Models.Customers", b =>
                {
                    b.Navigation("RentalHeader");
                });

            modelBuilder.Entity("MovieRental.Models.RentalHeader", b =>
                {
                    b.Navigation("RentalDetails");
                });

            modelBuilder.Entity("MovieShopRental.Models.Movie", b =>
                {
                    b.Navigation("RentalDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
