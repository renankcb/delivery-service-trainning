using DeliveryService.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public interface IQueriesService
    {
        Task<Point> GetById(int id);

        Task<IEnumerable<Point>> GetAll();
    }
}
