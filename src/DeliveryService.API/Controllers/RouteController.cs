using DeliveryService.API.Dto;
using DeliveryService.API.Services;
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
        private readonly IRoutesService _service;

        public RouteController(IRoutesService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("getRouteFromOriginToDestination")]
        public async Task<ActionResult<ResultResponse<IEnumerable<RouteResponse>>>> Get([FromQuery(Name = "originId")] int originId, [FromQuery(Name = "destinationId")]int destinationId)
        {
            return await _service.GetRouteFromOriginToDestination(originId, destinationId);
        }
    }
}