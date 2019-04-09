using Microsoft.EntityFrameworkCore;

namespace DeliveryService.API.Model
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Point> Points { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<RoutePoints> RoutePoints { get; set; }

        public DeliveryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Point>().ToTable("Points");
            modelBuilder.Entity<Point>().HasKey(p => p.Id);
            modelBuilder.Entity<Point>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Point>().Property(p => p.Name).IsRequired();*/

            modelBuilder.Entity<RoutePoints>().HasKey(rp => new { rp.Id });
            modelBuilder.Entity<RoutePoints>().Property(rp => rp.PointId);
            modelBuilder.Entity<RoutePoints>().Property(rp => rp.RouteId);

            modelBuilder.Entity<RoutePoints>()
                .HasOne<Point>(rp => rp.Point)
                .WithMany(p => p.RoutePoints)
                .HasForeignKey(rp => rp.PointId);


            modelBuilder.Entity<RoutePoints>()
                .HasOne<Route>(rp => rp.Route)
                .WithMany(r => r.RoutePoints)
                .HasForeignKey(rp => rp.RouteId);
        }
    }
}
