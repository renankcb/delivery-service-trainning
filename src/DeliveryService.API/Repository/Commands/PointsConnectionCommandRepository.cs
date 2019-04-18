using DeliveryService.API.Model;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    public class PointsConnectionCommandRepository : ICommandRepository<PointsConnection>
    {
        private readonly DeliveryContext _context;

        public PointsConnectionCommandRepository(DeliveryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PointsConnection> Save(PointsConnection newPointsConnection)
        {
            await _context.PointsConnection.AddAsync(newPointsConnection);

            await _context.SaveChangesAsync();

            return newPointsConnection;
        }

        public async Task<PointsConnection> Update(PointsConnection pointsConnection)
        {
            _context.PointsConnection.Update(pointsConnection);

            await _context.SaveChangesAsync();

            return pointsConnection;
        }

        public async Task<PointsConnection> Delete(PointsConnection pointsConnection)
        {
            _context.PointsConnection.Remove(pointsConnection);

            await _context.SaveChangesAsync();

            return pointsConnection;
        }
    }
}
