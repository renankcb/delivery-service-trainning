using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    public class PointCommandService : ICommandService<Point>
    {
        private readonly DeliveryContext _context;

        public PointCommandService(DeliveryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ResultResponse<Point>> Save(Point newPoint)
        {
            ResultResponse<Point> result = new ResultResponse<Point>();

            try
            {
                await _context.Points.AddAsync(newPoint);

                await _context.SaveChangesAsync();

                result.Success = true;
                result.Data = newPoint;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultResponse<Point>> Update(Point point)
        {

            ResultResponse<Point> result = new ResultResponse<Point>();

            try
            {
                var currentPoint = await _context.Points.FindAsync(point.Id);

                if (currentPoint == null)
                {
                    throw new InvalidOperationException("Point not found");
                }
                currentPoint.Name = point.Name;

                _context.Points.Update(currentPoint);

                await _context.SaveChangesAsync();

                result.Success = true;
                result.Data = currentPoint;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultResponse<Point>> Delete(int id)
        {
            ResultResponse<Point> result = new ResultResponse<Point>();

            try
            {
                var currentPoint = await _context.Points.FindAsync(id);

                if (currentPoint == null)
                {
                    throw new InvalidOperationException("Point not found");
                }

                _context.Points.Remove(currentPoint);

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
