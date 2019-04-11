using DeliveryService.API.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public interface IService<T>
    {
        Task<ResultResponse<T>> GetById(int id);

        Task<ResultResponse<IEnumerable<T>>> GetAllAsync();

        Task<ResultResponse<T>> Save(T point);

        Task<ResultResponse<T>> Update(T point);

        Task<ResultResponse<T>> Delete(int id);
    }
}
