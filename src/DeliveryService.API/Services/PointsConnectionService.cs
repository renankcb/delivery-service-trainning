using DeliveryService.API.Commands;
using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public class PointsConnectionService : BaseService<PointsConnection>, IService<PointsConnection>, IPointsConnectionService
    {
        public PointsConnectionService(AbstractQueriesRepository<PointsConnection> queries, ICommandRepository<PointsConnection> commands) : base(queries, commands)
        {
        }

        public async Task<ResultResponse<IEnumerable<PointsConnection>>> GetAllAsync()
        {
            ResultResponse<IEnumerable<PointsConnection>> result = new ResultResponse<IEnumerable<PointsConnection>>();

            var resultFromDb = await _queriesRepository.GetAllAsync();
            result.Success = true;
            result.Data = resultFromDb;

            return result;
        }

        public async Task<ResultResponse<PointsConnection>> GetByIdAsync(int id)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            var resultFromDb = await _queriesRepository.GetById(id);
            if (resultFromDb == null)
            {
                return null;
            }
            else
            {
                result.Success = true;
                result.Data = resultFromDb;
            }

            return result;
        }

        public async Task<ResultResponse<PointsConnection>> SaveAsync(PointsConnection connectionPoint)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            var currentPointsConnection = await ((PointsConnectionQueriesRepository)_queriesRepository)
                                            .FindByOriginAndDestination(connectionPoint.OriginId, connectionPoint.DestinationId);

            if (currentPointsConnection.Any())
            {
                throw new InvalidOperationException("Connection already existes");
            }

            await _commandsRepository.Save(connectionPoint);

            result.Success = true;
            result.Data = connectionPoint;

            return result;

        }

        public async Task<ResultResponse<PointsConnection>> UpdateAsync(PointsConnection point)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            var currentPointsConnection = await _queriesRepository.GetById(point.Id);

            if (currentPointsConnection == null)
            {
                throw new InvalidOperationException("PointsConnection not found");
            }

            currentPointsConnection.OriginId = point.OriginId;
            currentPointsConnection.DestinationId = point.DestinationId;
            currentPointsConnection.Time = point.Time;
            currentPointsConnection.Cost = point.Cost;

            result.Success = true;
            result.Data = await _commandsRepository.Update(currentPointsConnection);

            return result;

        }

        public async Task<ResultResponse<PointsConnection>> DeleteAsync(int id)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            var currentPointsConnection = await _queriesRepository.GetById(id);

            if (currentPointsConnection == null)
            {
                throw new InvalidOperationException("PointsConnection not found");
            }

            await _commandsRepository.Delete(currentPointsConnection);

            result.Success = true;
            return result;

        }

        public async Task<IEnumerable<PointsConnection>> FindByOriginAndDestination(int originId, int destinationId)
        {
            return await ((PointsConnectionQueriesRepository)_queriesRepository)
                                                .FindByOriginAndDestination(originId, destinationId);
        }
    }
}
