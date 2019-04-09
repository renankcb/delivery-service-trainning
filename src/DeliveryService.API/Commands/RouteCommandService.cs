using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    public class RouteCommandService : ICommandService<Route>
    {
        private readonly DeliveryContext _context;

        public RouteCommandService(DeliveryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ResultResponse<Route>> Save(Route newRoute)
        {
            ResultResponse<Route> result = new ResultResponse<Route>();

            try
            {
                await _context.Routes.AddAsync(newRoute);

                await _context.SaveChangesAsync();

                result.Success = true;
                result.Data = newRoute;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultResponse<Route>> Update(Route route)
        {
            ResultResponse<Route> result = new ResultResponse<Route>();

            try
            {
                var currentRoute = await _context.Routes.FindAsync(route.Id);

                if (currentRoute == null)
                {
                    throw new InvalidOperationException("Route not found");
                }

                //mapear atualizacao
                _context.Routes.Update(currentRoute);

                await _context.SaveChangesAsync();

                result.Success = true;
                result.Data = currentRoute;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultResponse<Route>> Delete(int id)
        {
            ResultResponse<Route> result = new ResultResponse<Route>();

            try
            {
                var currentRoute = await _context.Routes.FindAsync(id);

                if (currentRoute == null)
                {
                    throw new InvalidOperationException("Route not found");
                }

                _context.Routes.Remove(currentRoute);

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
