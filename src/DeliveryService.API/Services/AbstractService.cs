

using DeliveryService.API.Commands;
using DeliveryService.API.Dto;
using DeliveryService.API.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public abstract class AbstractService<T> : IService<T>
    {
        protected readonly AbstractQueriesRepository<T> _queriesRepository;

        protected readonly ICommandRepository<T> _commandsRepository;

        public AbstractService(AbstractQueriesRepository<T> queries, ICommandRepository<T> commands)
        {
            _queriesRepository = queries ?? throw new ArgumentNullException(nameof(queries));
            _commandsRepository = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public abstract Task<ResultResponse<T>> GetById(int id);

        public abstract Task<ResultResponse<IEnumerable<T>>> GetAllAsync();

        public abstract Task<ResultResponse<T>> Save(T point);

        public abstract Task<ResultResponse<T>> Update(T point);

        public abstract Task<ResultResponse<T>> Delete(int id);
    }
}
