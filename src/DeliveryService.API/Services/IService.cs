using DeliveryService.API.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public interface IService<T>
    {
        Task<ResultResponse<T>> GetByIdAsync(int id);

        Task<ResultResponse<IEnumerable<T>>> GetAllAsync();

        Task<ResultResponse<T>> SaveAsync(T point);

        Task<ResultResponse<T>> UpdateAsync(T point);

        Task<ResultResponse<T>> DeleteAsync(int id);
    }
}
