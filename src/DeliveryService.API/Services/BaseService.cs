

using DeliveryService.API.Commands;
using DeliveryService.API.Dto;
using DeliveryService.API.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public class BaseService<T>
    {
        protected readonly AbstractQueriesRepository<T> _queriesRepository;

        protected readonly ICommandRepository<T> _commandsRepository;

        public BaseService(AbstractQueriesRepository<T> queries, ICommandRepository<T> commands)
        {
            _queriesRepository = queries ?? throw new ArgumentNullException(nameof(queries));
            _commandsRepository = commands ?? throw new ArgumentNullException(nameof(commands));
        }
    }
}
