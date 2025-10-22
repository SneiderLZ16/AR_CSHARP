using Microsoft.EntityFrameworkCore;
using SkyTravel.Web.Models;

namespace SkyTravel.Web.Data
{
    public class SkyTravelDbContext : DbContext
    {
        public SkyTravelDbContext(DbContextOptions<SkyTravelDbContext> options) : base(options) { }

        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<Passenger> Passengers => Set<Passenger>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<TicketHistory> TicketHistories => Set<TicketHistory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasIndex(f => f.Code)
                .IsUnique();

            modelBuilder.Entity<Passenger>()
                .HasIndex(p => p.Document)
                .IsUnique();

            modelBuilder.Entity<Reservation>()
                .HasIndex(r => r.ReservationCode)
                .IsUnique();

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Flight)
                .WithMany(f => f.Reservations)
                .HasForeignKey(r => r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Passenger)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
