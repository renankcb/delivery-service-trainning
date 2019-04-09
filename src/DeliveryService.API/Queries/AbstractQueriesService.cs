using DeliveryService.API.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public abstract class AbstractQueriesService<T>
    {
        protected readonly string _connectionString;

        public AbstractQueriesService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public abstract Task<ResultResponse<T>> GetById(int id);

        public abstract Task<ResultResponse<IEnumerable<T>>> GetAll();
    }
}
