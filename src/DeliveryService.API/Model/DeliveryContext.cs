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


            modelBuilder.Entity<Point>().HasData(
                new
                {
                    Id = 1,
                    Name = "A"
                },
                new
                {
                    Id = 2,
                    Name = "B"
                },
                new
                {
                    Id = 3,
                    Name = "C"
                },
                new
                {
                    Id = 4,
                    Name = "D"
                },
                new
                {
                    Id = 5,
                    Name = "E"
                },
                new
                {
                    Id = 7,
                    Name = "K"
                });

            modelBuilder.Entity<PointsConnection>().HasData(
                new
                {
                    Id = 3,
                    OriginId = 1,
                    DestinationId = 2,
                    Time = 1,
                    Cost = 5
                },
                new
                {
                    Id = 5,
                    OriginId = 2,
                    DestinationId = 3,
                    Time = 2,
                    Cost = 10

                },
                new
                {
                    Id = 6,
                    OriginId = 1,
                    DestinationId = 3,
                    Time = 2,
                    Cost = 2

                },
                new
                {
                    Id = 7,
                    OriginId = 1,
                    DestinationId = 4,
                    Time = 4,
                    Cost = 20

                },
                new
                {
                    Id = 8,
                    OriginId = 4,
                    DestinationId = 5,
                    Time = 2,
                    Cost = 10

                },
                new
                {
                    Id = 9,
                    OriginId = 5,
                    DestinationId = 3,
                    Time = 3,
                    Cost = 15

                },
                new
                {
                    Id = 10,
                    OriginId = 4,
                    DestinationId = 7,
                    Time = 3,
                    Cost = 15

                },
                new
                {
                    Id = 11,
                    OriginId = 7,
                    DestinationId = 5,
                    Time = 2,
                    Cost = 10

                },
                new
                {
                    Id = 12,
                    OriginId = 1,
                    DestinationId = 7,
                    Time = 5,
                    Cost = 25

                });
        }
    }
}
