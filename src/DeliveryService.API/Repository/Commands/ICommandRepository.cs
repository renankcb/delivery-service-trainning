using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    public interface ICommandRepository<T>
    {
        Task<T> Save(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);
    }
}
