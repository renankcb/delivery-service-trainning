using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Services;
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
        private readonly AbstractService<PointsConnection> _service;

        public PointsConnectionController(AbstractService<PointsConnection> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult<ResultResponse<IEnumerable<PointsConnection>>>> Get()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Get(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Post(PostPointsConnectionDto value)
        {
            if (!value.IsValid())
                return ReturnBadRequest();

            return await _service.Save(value.ToDomain());
        }

        [HttpPut]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Put(PostPointsConnectionDto value)
        {
            if (!value.IsValid())
                return ReturnBadRequest();

            return await _service.Update(value.ToDomain());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}