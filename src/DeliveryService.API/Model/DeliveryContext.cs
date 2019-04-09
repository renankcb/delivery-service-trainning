using Microsoft.EntityFrameworkCore;

namespace DeliveryService.API.Model
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Point> Points { get; set; }

        public DeliveryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Point>().ToTable("Points");
            modelBuilder.Entity<Point>().HasKey(p => p.Id);
            modelBuilder.Entity<Point>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Point>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Point>().Property(p => p.Time).IsRequired();
            modelBuilder.Entity<Point>().Property(p => p.Cost).IsRequired();
        }
    }
}
