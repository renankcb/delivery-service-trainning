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
    public class RouteController : ControllerBase
    {
        private readonly AbstractQueriesService<Route> _queries;

        private readonly ICommandService<Route> _commands;

        public RouteController(AbstractQueriesService<Route> queries, ICommandService<Route> commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet]
        public async Task<ActionResult<ResultResponse<IEnumerable<Route>>>> Get()
        {
            return await _queries.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<Route>>> Get(int id)
        {
            return await _queries.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ResultResponse<Route>>> Post(PostRouteDto value)
        {
            if (!value.IsValid())
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Invalid data!"
                });
            }

            return await _commands.Save(value.ToDomain());
        }

        [HttpPut]
        public async Task<ActionResult<ResultResponse<Route>>> Put(PostRouteDto value)
        {
            if (!value.IsValid())
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Invalid data!"
                });
            }

            return await _commands.Update(value.ToDomain());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<Route>>> Delete(int id)
        {
            return await _commands.Delete(id);
        }
    }
}