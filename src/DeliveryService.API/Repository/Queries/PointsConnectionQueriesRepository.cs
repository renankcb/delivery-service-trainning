using Dapper;
using DeliveryService.API.Model;
using DeliveryService.API.Repository.Queries;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public class PointsConnectionQueriesRepository : AbstractQueriesRepository<PointsConnection>, IPointsConnectionQueriesService
    {
        public PointsConnectionQueriesRepository(string connectionString) : base(connectionString) { }

        public override async Task<IEnumerable<PointsConnection>> GetAllAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"select pc.Id, pc.OriginId, pc.DestinationId, pc.Time, pc.Cost, po.Id, po.Name, pd.Id, pd.Name from dbo.PointsConnection pc " +
                "join dbo.Points po on pc.OriginId = po.Id " +
                "join dbo.Points pd on pc.DestinationId = pd.Id";

                var resultFromDb = await conn.QueryAsync<PointsConnection, Point, Point, PointsConnection>(query,
                    (pointConnection, origin, destination) =>
                    { pointConnection.Origin = origin; pointConnection.Destination = destination; return pointConnection; },
                    splitOn: "Id, Id, Id");

                return resultFromDb;
            }
        }

        public override async Task<PointsConnection> GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"select pc.Id, pc.OriginId, pc.DestinationId, pc.Time, pc.Cost, po.Id, po.Name, pd.Id, pd.Name from dbo.PointsConnection pc " +
                "join dbo.Points po on pc.OriginId = po.Id " +
                "join dbo.Points pd on pc.DestinationId = pd.Id " +
                " WHERE pc.Id = @ID;";

                var resultFromDb = await conn.QueryAsync<PointsConnection, Point, Point, PointsConnection>(query,
                    (pointConnection, origin, destination) =>
                    { pointConnection.Origin = origin; pointConnection.Destination = destination; return pointConnection; },
                    new { ID = id },
                    splitOn: "Id, Id, Id");

                return resultFromDb.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<PointsConnection>> FindByOriginAndDestination(int? originId, int? destinationId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query  = @"select pc.Id, pc.OriginId, pc.DestinationId, pc.Time, pc.Cost, po.Id, po.Name, pd.Id, pd.Name from dbo.PointsConnection pc " +
                "join dbo.Points po on pc.OriginId = po.Id " + 
                "join dbo.Points pd on pc.DestinationId = pd.Id " +
                "WHERE OriginId = @ORIGIN_ID AND DestinationId = @DESTINATION_ID;";

                var resultFromDb = await conn.QueryAsync<PointsConnection, Point, Point, PointsConnection>(query, 
                    (pointConnection, origin, destination) => 
                    { pointConnection.Origin = origin; pointConnection.Destination = destination; return pointConnection; },
                    new { ORIGIN_ID = originId, DESTINATION_ID = destinationId },
                    splitOn: "Id, Id, Id");

                return resultFromDb;
            }
        }
    }
}
