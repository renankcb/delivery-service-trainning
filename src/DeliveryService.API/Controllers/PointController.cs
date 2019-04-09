using DeliveryService.API.Commands;
using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IQueriesService _queries;

        private readonly ICommandService _commands;

        public PointController(IQueriesService queries, ICommandService commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Point>>> Get()
        {
            return (await _queries.GetAll()).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Point>> Get(int id)
        {
            return await _queries.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Point>> Post(PostPointDto value)
        {
            return await _commands.SavePoint(value.Name, value.Time, value.Cost);
        }

        [HttpPut]
        public async Task<ActionResult<Point>> Put(PostPointDto value)
        {
            return await _commands.UpdatePoint(value.Id, value.Name, value.Time, value.Cost);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Point>> Delete(int id)
        {
            return await _commands.DeletePoint(id);
        }
    }
}