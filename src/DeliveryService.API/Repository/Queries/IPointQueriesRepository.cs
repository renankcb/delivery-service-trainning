using DeliveryService.API.Model;
using System.Threading.Tasks;

namespace DeliveryService.API.Repository.Queries
{
    public interface IPointQueriesRepository<T>
    {
        Task<Point> FindByName(string name);
    }
}
