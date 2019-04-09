using Dapper;
using DeliveryService.API.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public class QueriesService : IQueriesService
    {
        private readonly string _connectionString;

        public QueriesService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Point>> GetAll()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                return await conn.QueryAsync<Point>("SELECT * FROM dbo.Points;");
            }
        }

        public async Task<Point> GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM dbo.Points WHERE @id;";

                var result = await conn.QueryAsync<Point>(query, new { ID = id });

                return result.FirstOrDefault();
            }
        }
    }
}
