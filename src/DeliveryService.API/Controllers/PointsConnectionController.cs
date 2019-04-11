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
    public class PointsConnectionController : ControllerBase
    {
        private readonly BaseService<PointsConnection> _service;

        public PointsConnectionController(BaseService<PointsConnection> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult<ResultResponse<IEnumerable<PointsConnection>>>> Get()
        {
            try
            {
                return await ((PointsConnectionService)_service).GetAllAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Get(int id)
        {
            try
            {
                return await ((PointsConnectionService)_service).GetById(id);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Post(PostPointsConnectionDto value)
        {
            if (!value.IsValid())
                return BadRequest("Invalida data!");

            try
            {
                return await ((PointsConnectionService)_service).Save(value.ToDomain());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Put(PostPointsConnectionDto value)
        {
            if (!value.IsValid())
                return BadRequest("Invalida data!");

            try
            {
                return await ((PointsConnectionService)_service).Update(value.ToDomain());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Delete(int id)
        {
            try
            {
                return await ((PointsConnectionService)_service).Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}