using DeliveryService.API.Dto;
using DeliveryService.API.Exceptions;
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
    public class PointController : ControllerBase
    {
        private readonly BaseService<Point> _service;

        public PointController(BaseService<Point> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult<ResultResponse<IEnumerable<Point>>>> Get()
        {
            try
            {
                return await ((PointService)_service).GetAllAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<Point>>> Get(int id)
        {
            try
            {
                return await ((PointService)_service).GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResultResponse<Point>>> Post(PostPointDto value)
        {
            if (!value.IsValid())
                return BadRequest("Invalida data!");

            try
            {
                return await ((PointService)_service).Save(value.ToDomain());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ResultResponse<Point>>> Put(PostPointDto value)
        {
            if (!value.IsValid())
                return BadRequest("Invalida data!");

            try
            {
                return await ((PointService)_service).Update(value.ToDomain());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<Point>>> Delete(int id)
        {
            try
            {
                return await ((PointService)_service).Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}