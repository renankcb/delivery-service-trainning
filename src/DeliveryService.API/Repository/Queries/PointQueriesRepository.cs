using Dapper;
using DeliveryService.API.Model;
using DeliveryService.API.Repository.Queries;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public class PointQueriesRepository : AbstractQueriesRepository<Point>, IPointQueriesRepository
    {
        public PointQueriesRepository(string connectionString) : base(connectionString) { }

        public async override Task<IEnumerable<Point>> GetAllAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                var query = @"SELECT Id, Name FROM dbo.Points;";

                return await conn.QueryAsync<Point>(query);
            }
        }

        public async override Task<Point> GetById(int id)
        {

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT Id, Name FROM dbo.Points WHERE Id = @ID;";

                var resultFromDb = await conn.QueryAsync<Point>(query, new { ID = id });

                return resultFromDb.FirstOrDefault();
            }
        }

        public async Task<Point> FindByName(string name)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT Id, Name FROM dbo.Points WHERE Name = @NAME;";

                var resultFromDb = await conn.QueryAsync<Point>(query, new { NAME = name });

                return resultFromDb.FirstOrDefault();
            }
        }
    }
}
