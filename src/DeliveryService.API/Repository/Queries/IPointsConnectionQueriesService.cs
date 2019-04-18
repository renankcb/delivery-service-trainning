using DeliveryService.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Repository.Queries
{
    public interface IPointsConnectionQueriesService
    {
        Task<IEnumerable<PointsConnection>> FindByOriginAndDestination(int? originId, int? destinationId);
    }
}
