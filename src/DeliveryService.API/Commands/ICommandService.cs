using DeliveryService.API.Model;
using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    public interface ICommandService
    {
        Task<Point> SavePoint(string name, int time, int cost);

        Task<Point> UpdatePoint(int id, string name, int time, int cost);

        Task<Point> DeletePoint(int id);
    }
}
