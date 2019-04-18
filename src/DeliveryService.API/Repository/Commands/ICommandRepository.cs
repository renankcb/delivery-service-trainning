using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    /// <summary>
    /// Interface with methods to be implemented to database writing
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandRepository<T>
    {
        Task<T> Save(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);
    }
}
