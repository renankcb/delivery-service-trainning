using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    public class PointsConnectionCommandService : ICommandService<PointsConnection>
    {
        private readonly DeliveryContext _context;

        public PointsConnectionCommandService(DeliveryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ResultResponse<PointsConnection>> Save(PointsConnection newPointsConnection)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            try
            {
                await _context.PointsConnection.AddAsync(newPointsConnection);

                await _context.SaveChangesAsync();

                result.Success = true;
                result.Data = newPointsConnection;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultResponse<PointsConnection>> Update(PointsConnection pointsConnection)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            try
            {
                var currentPointsConnection = await _context.PointsConnection.FindAsync(pointsConnection.Id);

                if (currentPointsConnection == null)
                {
                    throw new InvalidOperationException("PointsConnection not found");
                }

                currentPointsConnection.OriginId = pointsConnection.OriginId;
                currentPointsConnection.DestinationId = pointsConnection.DestinationId;
                currentPointsConnection.Time = pointsConnection.Time;
                currentPointsConnection.Cost = pointsConnection.Cost;
                _context.PointsConnection.Update(currentPointsConnection);

                await _context.SaveChangesAsync();

                result.Success = true;
                result.Data = currentPointsConnection;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultResponse<PointsConnection>> Delete(int id)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            try
            {
                var currentPointsConnection = await _context.PointsConnection.FindAsync(id);

                if (currentPointsConnection == null)
                {
                    throw new InvalidOperationException("PointsConnection not found");
                }

                _context.PointsConnection.Remove(currentPointsConnection);

                await _context.SaveChangesAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
