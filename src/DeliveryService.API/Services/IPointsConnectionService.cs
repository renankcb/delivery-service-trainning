using DeliveryService.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public interface IPointsConnectionService
    {
        Task<IEnumerable<PointsConnection>> FindByOriginAndDestination(int originId, int destinationId);
    }
}
