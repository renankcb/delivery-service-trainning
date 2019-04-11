using DeliveryService.API.Commands;
using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public class PointsConnectionService : AbstractService<PointsConnection>
    {
        public PointsConnectionService(AbstractQueriesRepository<PointsConnection> queries, ICommandRepository<PointsConnection> commands) : base(queries, commands)
        {
        }

        public override async Task<ResultResponse<IEnumerable<PointsConnection>>> GetAllAsync()
        {
            ResultResponse<IEnumerable<PointsConnection>> result = new ResultResponse<IEnumerable<PointsConnection>>();

            try
            {
                var resultFromDb = await _queriesRepository.GetAllAsync();
                result.Success = true;
                result.Data = resultFromDb;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public override async Task<ResultResponse<PointsConnection>> GetById(int id)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            try
            {
                var resultFromDb = await _queriesRepository.GetById(id);
                if (resultFromDb == null)
                {
                    throw new Exception("Register not found");
                }
                else
                {
                    result.Success = true;
                    result.Data = resultFromDb;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public override async Task<ResultResponse<PointsConnection>> Save(PointsConnection connectionPoint)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            try
            {
                var currentPointsConnection = await ((PointsConnectionQueriesRepository)_queriesRepository)
                                                .FindByOriginAndDestination(connectionPoint.OriginId, connectionPoint.DestinationId);

                if (currentPointsConnection != null)
                {
                    throw new Exception("Connection already existes");
                }

                await _commandsRepository.Save(connectionPoint);

                result.Success = true;
                result.Data = connectionPoint;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public override async Task<ResultResponse<PointsConnection>> Update(PointsConnection point)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            try
            {
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

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public override async Task<ResultResponse<PointsConnection>> Delete(int id)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            try
            {
                var currentPointsConnection = await _queriesRepository.GetById(id);

                if (currentPointsConnection == null)
                {
                    throw new InvalidOperationException("PointsConnection not found");
                }

                await _commandsRepository.Delete(currentPointsConnection);

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
