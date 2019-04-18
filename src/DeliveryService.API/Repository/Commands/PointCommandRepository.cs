using DeliveryService.API.Model;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    public class PointCommandRepository : ICommandRepository<Point>
    {
        private readonly DeliveryContext _context;

        public PointCommandRepository(DeliveryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Point> Save(Point newPoint)
        {
            await _context.Points.AddAsync(newPoint);

            await _context.SaveChangesAsync();

            return newPoint;
        }

        public async Task<Point> Update(Point point)
        {
            _context.Points.Update(point);

            await _context.SaveChangesAsync();

            return point;
        }

        public async Task<Point> Delete(Point point)
        {
            _context.Points.Remove(point);

            await _context.SaveChangesAsync();

            return point;
        }
    }
}
