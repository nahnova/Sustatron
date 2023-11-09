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
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Commute> Commutes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=desktop-fs0t5ua;Initial Catalog=SustatronDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=false;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints here

            // Define the relationship between User and Achievement (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Vehicles)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Commute)
                .WithOne(a => a.User)
                .HasForeignKey<Commute>(a => a.UserId);

            // Call base method
            base.OnModelCreating(modelBuilder);
        }

    }
}