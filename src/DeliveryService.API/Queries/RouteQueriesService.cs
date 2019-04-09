using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public class RouteQueriesService : AbstractQueriesService<Route>
    {
        public RouteQueriesService(string connectionString) : base(connectionString) { }

        public override Task<ResultResponse<IEnumerable<Route>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<ResultResponse<Route>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
