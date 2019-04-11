using DeliveryService.API.Model;
using System.Threading.Tasks;

namespace DeliveryService.API.Repository.Queries
{
    public interface IPointsConnectionQueriesService<T>
    {
        Task<PointsConnection> FindByOriginAndDestination(int? originId, int? destinationId);
    }
}
