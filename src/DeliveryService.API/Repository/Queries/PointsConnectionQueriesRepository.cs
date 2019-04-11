using Dapper;
using DeliveryService.API.Model;
using DeliveryService.API.Repository.Queries;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public class PointsConnectionQueriesRepository : AbstractQueriesRepository<PointsConnection>, IPointsConnectionQueriesService<PointsConnection>
    {
        public PointsConnectionQueriesRepository(string connectionString) : base(connectionString) { }

        public override async Task<IEnumerable<PointsConnection>> GetAllAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                var query = @"SELECT Id, OriginId, DestinationId, Time, Cost FROM dbo.PointsConnection;";

                var resultFromDb = await conn.QueryAsync<PointsConnection>(query);

                return resultFromDb;
            }
        }

        public override async Task<PointsConnection> GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT Id, OriginId, DestinationId, Time, Cost FROM dbo.PointsConnection WHERE Id = @ID;";

                var resultFromDb = await conn.QueryAsync<PointsConnection>(query, new { ID = id });

                return resultFromDb.FirstOrDefault();
            }
        }

        public async Task<PointsConnection> FindByOriginAndDestination(int? originId, int? destinationId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT Id, OriginId, DestinationId, Time, Cost FROM dbo.PointsConnection WHERE OriginId = @ORIGIN_ID AND DestinationId = @DESTINATION_ID;";

                var resultFromDb = await conn.QueryAsync<PointsConnection>(query, new { ORIGIN_ID = originId, DESTINATION_ID = destinationId });

                return resultFromDb.FirstOrDefault();
            }
        }
    }
}
