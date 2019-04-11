using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using System;
using System.Collections.Generic;
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

        public async Task<ResultResponse<IEnumerable<RouteResponse>>> GetRouteFromOriginToDestination(int originId, int destinationId)
        {
            var result = new ResultResponse<IEnumerable<RouteResponse>>();

            result.Success = true;
            var connections = await _queriesRepository.GetAllAsync();
            List<PointsPathDto> pointsPath = BuildDto(connections);



            result.Data = new List<RouteResponse>() { new RouteResponse() { Test = "foi" } };
            return result;
        }

        private List<PointsPathDto> BuildDto(IEnumerable<PointsConnection> connections)
        {
            var result = new List<PointsPathDto>();
            foreach (var con in connections)
            {
                result.Add(new PointsPathDto()
                {
                    Id = con.Id,
                    OriginPointId = con.OriginId.Value,
                    DestinationPointId = con.DestinationId.Value,
                    Time = con.Time,
                    Cost = con.Cost
                });
            }
            return result;
        }

        private void FindRoute(int originId, int destinationId, List<PointsPathDto> pointsConnection, List<PointsPathDto> visitedPoints)
        {

        }
    }
}
