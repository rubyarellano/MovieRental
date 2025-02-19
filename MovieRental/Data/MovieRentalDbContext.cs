using Microsoft.EntityFrameworkCore;
using MovieRental.Models;
using MovieShopRental.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MovieRental.Data
{
    public class MovieRentalDbContext : DbContext
    {
        public MovieRentalDbContext(DbContextOptions<MovieRentalDbContext> options) : base(options) { }

        public DbSet<Customers>? Customer { get; set; }

        public DbSet<Movie>? Movies{ get; set; }

        public DbSet<RentalDetail>? RentalDetails { get; set; }

        public DbSet<RentalHeader>? RentalHeader { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.MovieId);
                entity.Property(m => m.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(m => m.Type)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(m => m.Director)
                    .IsRequired()
                    .HasMaxLength(100);
               
            });

            // Customer Configuration
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.LastName);
                 entity.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("Latin1_General_CI_AS");
                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Number)
                    .HasMaxLength(100);  
                entity.Property(c => c.Address)
                    .IsRequired()
                   .HasMaxLength(100)
                    .UseCollation(" Latin1_General_CI_AS");
                entity.Property(c => c.BirthDate)
                    .IsRequired();
            });

            // RentalHeader Configuration
            modelBuilder.Entity<RentalHeader>(entity =>
            {
                entity.HasKey(rh => rh.RentalHeaderId);
                entity.HasOne(rh => rh.Customer)
                    .WithMany(c => c.RentalHeader)
                    .HasForeignKey(rh => rh.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.Property(rh => rh.RentalDate)
                    .HasDefaultValueSql("GETDATE()");
            });

            // RentalDetail Configuration
            modelBuilder.Entity<RentalDetail>(entity =>
            {
                entity.HasKey(rd => rd.RentalDetailId);
                entity.Property(rd => rd.RentalHeaderId)
                    .ValueGeneratedOnAdd();

                // Correct foreign key for RentalHeader
                entity.HasOne(rd => rd.RentalHeader)
                    .WithMany(rh => rh.RentalDetails)
                    .HasForeignKey(rd => rd.RentalHeaderId)  // Changed to use RentalHeaderId
                    .OnDelete(DeleteBehavior.Cascade);

                // Correct foreign key for Movie
                entity.HasOne(rd => rd.Movies)
                    .WithMany()
                    .HasForeignKey(rd => rd.MovieId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}



        

    

