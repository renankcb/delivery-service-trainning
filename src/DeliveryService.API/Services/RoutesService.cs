using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public class RoutesService : IRoutesService
    {
        protected readonly AbstractQueriesRepository<PointsConnection> _queriesRepository;

        public RoutesService(AbstractQueriesRepository<PointsConnection> queries)
        {
            _queriesRepository = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        public async Task<ResultResponse<Routes>> GetRouteFromOriginToDestination(int originId, int destinationId)
        {
            var result = new ResultResponse<Routes>();

            try
            {
                var connections = await _queriesRepository.GetAllAsync();

                var routes = new Routes(originId, destinationId, connections.ToList());

                result.Success = true;
                result.Data = routes;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
