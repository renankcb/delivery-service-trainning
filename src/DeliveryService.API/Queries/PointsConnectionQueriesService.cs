using Dapper;
using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public class PointsConnectionQueriesService : AbstractQueriesService<PointsConnection>
    {
        public PointsConnectionQueriesService(string connectionString) : base(connectionString) { }

        public override async Task<ResultResponse<IEnumerable<PointsConnection>>> GetAllAsync()
        {
            ResultResponse<IEnumerable<PointsConnection>> result = new ResultResponse<IEnumerable<PointsConnection>>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    var query = @"SELECT Id, OriginId, DestinationId, Time, Cost FROM dbo.PointsConnection;";

                    var resultFromDb = await conn.QueryAsync<PointsConnection>(query);
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

        public override async Task<ResultResponse<PointsConnection>> GetById(int id)
        {
            ResultResponse<PointsConnection> result = new ResultResponse<PointsConnection>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"SELECT Id, OriginId, DestinationId, Time, Cost FROM dbo.PointsConnection WHERE Id = @ID;";

                    var resultFromDb = await conn.QueryAsync<PointsConnection>(query, new { ID = id });
                    if (!resultFromDb.Any())
                    {
                        throw new Exception("Register not found");
                    }
                    else
                    {
                        result.Success = true;
                        result.Data = resultFromDb.FirstOrDefault();
                    }
                }
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
