using Microsoft.EntityFrameworkCore;
using Sustatron.Models;

namespace Sustatron.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Commute> Commutes { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<ParkingLocation> ParkingLocations{ get; set; }
        public DbSet<SustainabilityMetric> SustainabilityMetrics { get; set; }
        public DbSet<TrafficReport> TrafficReports { get; set; }
        public DbSet<TransportationOption> TransportationOptions { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints here

            // Define the relationship between User and Achievement (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Achievements)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Define the relationship between Commute and User (Many-to-One)
            modelBuilder.Entity<Commute>()
                .HasOne(c => c.User)
                .WithMany(u => u.Commutes)
                .HasForeignKey(c => c.UserId);

            // Define the relationship between Commute and TransportationOption (Many-to-One)
            modelBuilder.Entity<Commute>()
                .HasOne(c => c.TransportationOption)
                .WithMany(to => to.Commutes)
                .HasForeignKey(c => c.TransportationOptionId);

            // Define other relationships as needed...

            // Specify SQL Server column types for decimal properties, if required

            // Call base method
            base.OnModelCreating(modelBuilder);
        }

    }
}