using DeliveryService.API.Commands;
using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsConnectionController : ApiController
    {
        private readonly AbstractQueriesService<PointsConnection> _queries;

        private readonly ICommandService<PointsConnection> _commands;

        public PointsConnectionController(AbstractQueriesService<PointsConnection> queries, ICommandService<PointsConnection> commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet]
        public async Task<ActionResult<ResultResponse<IEnumerable<PointsConnection>>>> Get()
        {
            return await _queries.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Get(int id)
        {
            return await _queries.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Post(PostPointsConnectionDto value)
        {
            if (!value.IsValid())
                return ReturnBadRequest();

            return await _commands.Save(value.ToDomain());
        }

        [HttpPut]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Put(PostPointsConnectionDto value)
        {
            if (!value.IsValid())
                return ReturnBadRequest();

            return await _commands.Update(value.ToDomain());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Delete(int id)
        {
            return await _commands.Delete(id);
        }
    }
}