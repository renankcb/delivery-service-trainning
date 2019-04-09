using System;
using System.Threading.Tasks;
using DeliveryService.API.Model;

namespace DeliveryService.API.Commands
{
    public class CommandService : ICommandService
    {
        private readonly DeliveryContext _context;

        public CommandService(DeliveryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Point> SavePoint(string name, int time, int cost)
        {
            var newPoint = new Point() { Name = name, Time = time, Cost = cost };

            await _context.Points.AddAsync(newPoint);

            await _context.SaveChangesAsync();

            return newPoint;
        }

        public async Task<Point> UpdatePoint(int id, string name, int time, int cost)
        {
            var currentPoint = await _context.Points.FindAsync(id);

            if (currentPoint == null)
                return null;

            currentPoint.Name = name;
            currentPoint.Time = time;
            currentPoint.Cost = cost;

            _context.Points.Update(currentPoint);

            await _context.SaveChangesAsync();

            return currentPoint;


        }

        public async Task<Point> DeletePoint(int id)
        {
            var currentPoint = await _context.Points.FindAsync(id);

            if (currentPoint == null)
                return null;

            _context.Points.Remove(currentPoint);

            await _context.SaveChangesAsync();

            return currentPoint;
        }
    }
}
