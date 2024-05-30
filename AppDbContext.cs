using CarPeak.Components.Classes;
using Microsoft.EntityFrameworkCore;

namespace CarPeak
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();  // This ensures EF knows Id is auto-incremented
        }
    }
}
