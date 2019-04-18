using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public interface IRoutesService
    {
        Task<ResultResponse<Routes>> GetRouteFromOriginToDestination(int originId, int destinationId);
    }
}
