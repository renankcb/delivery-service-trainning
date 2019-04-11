using DeliveryService.API.Model;
using System.Threading.Tasks;

namespace DeliveryService.API.Repository.Queries
{
    public interface IPointQueriesRepository
    {
        Task<Point> FindByName(string name);
    }
}
