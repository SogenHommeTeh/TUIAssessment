using Microsoft.EntityFrameworkCore;
using TUI.Data.Aircrafts.Models;
using TUI.Data.Airports.Models;
using TUI.Data.Flights.Models;

namespace TUI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AirportModel> Airports { get; set; }
        public DbSet<AircraftModel> Aircrafts { get; set; }
        public DbSet<FlightModel> Flights { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirportModel>()
                .HasIndex(x => x.PublicId).IsUnique();
            modelBuilder.Entity<AirportModel>()
                .HasIndex(x => x.CreatedAt);
            modelBuilder.Entity<AirportModel>()
                .HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<AirportModel>()
                .HasMany(x => x.DepartureFlights)
                .WithOne(x => x.DepartureAirport)
                .HasForeignKey(x => x.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AirportModel>()
                .HasMany(x => x.ArrivalFlights)
                .WithOne(x => x.ArrivalAirport)
                .HasForeignKey(x => x.ArrivalAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AircraftModel>()
                .HasIndex(x => x.PublicId).IsUnique();
            modelBuilder.Entity<AircraftModel>()
                .HasIndex(x => x.CreatedAt);
            modelBuilder.Entity<AircraftModel>()
                .HasIndex(x => x.Number).IsUnique();
            modelBuilder.Entity<AircraftModel>()
                .HasMany(x => x.Flights)
                .WithOne(x => x.Aircraft)
                .HasForeignKey(x => x.AircraftId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FlightModel>()
                .HasIndex(x => x.PublicId).IsUnique();
            modelBuilder.Entity<FlightModel>()
                .HasIndex(x => x.CreatedAt);
            modelBuilder.Entity<FlightModel>()
                .HasIndex(x => x.DepartureTime);
            modelBuilder.Entity<FlightModel>()
                .HasIndex(x => x.ArrivalTime);

            base.OnModelCreating(modelBuilder);
        }
    }
}
