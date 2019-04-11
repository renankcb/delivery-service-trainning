using DeliveryService.API.Commands;
using DeliveryService.API.Dto;
using DeliveryService.API.Exceptions;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public class PointService : BaseService<Point>, IService<Point>
    {
        public PointService(AbstractQueriesRepository<Point> queries, ICommandRepository<Point> commands) : base(queries, commands)
        {
        }

        public async Task<ResultResponse<IEnumerable<Point>>> GetAllAsync()
        {
            ResultResponse<IEnumerable<Point>> result = new ResultResponse<IEnumerable<Point>>();

            try
            {
                var resultFromDb = await _queriesRepository.GetAllAsync();
                result.Success = true;
                result.Data = resultFromDb;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultResponse<Point>> GetById(int id)
        {
            ResultResponse<Point> result = new ResultResponse<Point>();

            try
            {
                var resultFromDb = await _queriesRepository.GetById(id);

                if (resultFromDb == null)
                {
                    throw new NotFoundException();
                }
                else
                {
                    result.Success = true;
                    result.Data = resultFromDb;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultResponse<Point>> Save(Point point)
        {
            ResultResponse<Point> result = new ResultResponse<Point>();

            try
            {
                var resultFromDb = await ((PointQueriesRepository)_queriesRepository).FindByName(point.Name);

                if (resultFromDb != null)
                {
                    throw new InvalidOperationException("Register already exists!");
                }

                var newPoint = await _commandsRepository.Save(point);

                result.Success = true;
                result.Data = newPoint;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultResponse<Point>> Update(Point point)
        {
            ResultResponse<Point> result = new ResultResponse<Point>();

            try
            {
                var currentPoint = await _queriesRepository.GetById(point.Id);

                if (currentPoint == null)
                {
                    throw new InvalidOperationException("Point not found");
                }

                currentPoint.Name = point.Name;

                await _commandsRepository.Update(currentPoint);

                result.Success = true;
                result.Data = currentPoint;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultResponse<Point>> Delete(int id)
        {
            ResultResponse<Point> result = new ResultResponse<Point>();

            try
            {
                var currentPoint = await _queriesRepository.GetById(id);

                if (currentPoint == null)
                {
                    throw new InvalidOperationException("Point not found");
                }

                await _commandsRepository.Delete(currentPoint);

                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
