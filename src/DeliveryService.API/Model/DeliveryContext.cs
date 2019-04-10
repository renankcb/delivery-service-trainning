using Microsoft.EntityFrameworkCore;

namespace DeliveryService.API.Model
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Point> Points { get; set; }

        public DbSet<PointsConnection> PointsConnection { get; set; }

        public DeliveryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>()
                .HasMany(p => p.Origins)
                .WithOne(r => r.Origin)
                .HasForeignKey(p => p.OriginId)
                .IsRequired(false);

            modelBuilder.Entity<Point>()
                .HasMany(p => p.Destinations)
                .WithOne(r => r.Destination)
                .HasForeignKey(p => p.DestinationId)
                .IsRequired(false);
        }
    }
}
