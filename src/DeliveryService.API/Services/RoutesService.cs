using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using System;
using System.Collections.Generic;
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

        private void FindRoute(int originId, int destinationId, List<PointsPathDto> allPaths, List<PointsPathDto> visitedPoints, List<List<PointsPathDto>> allRoutes)
        {
            if (originId != destinationId)
            {
                var currentOriginChildren = allPaths.FindAll(pc => pc.OriginPointId == originId);

                foreach (var pc in currentOriginChildren)
                {
                    var currentOrigin = allPaths.Find(pci => pci.Id == pc.Id);
                    visitedPoints.Add(currentOrigin);

                    if (pc.DestinationPointId == destinationId)
                        allRoutes.Add(visitedPoints.ToList());

                    FindRoute(pc.DestinationPointId, destinationId, allPaths, visitedPoints, allRoutes);
                    visitedPoints.Remove(currentOrigin);
                }

            }
        }
    }
}
