using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public interface IRoutesService
    {
        Task<ResultResponse<IEnumerable<RouteResponse>>> GetRouteFromOriginToDestination(int originId, int destinationId);
    }
}
