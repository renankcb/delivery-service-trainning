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
    public class PointController : ControllerBase
    {
        private readonly BaseService<Point> _service;

        public PointController(BaseService<Point> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Return all registers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResultResponse<IEnumerable<Point>>>> GetAsync()
        {
            try
            {
                return await ((PointService)_service).GetAllAsync();
            }
            catch
            {
                return BadRequest("Error to retrieve data!");
            }
        }

        /// <summary>
        /// Return specific register by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<Point>>> GetAsync(int id)
        {
            try
            {
                var result = await ((PointService)_service).GetByIdAsync(id);
                if (result == null)
                    return NotFound();

                return result;
            }
            catch
            {
                return BadRequest("Error to retrieve data!");
            }
        }

        /// <summary>
        /// Add a new register
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResultResponse<Point>>> PostAsync(PostPointDto value)
        {
            if (!value.IsValid())
                return BadRequest("Invalida data!");

            try
            {
                return await ((PointService)_service).SaveAsync(value.ToDomain());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update an existent register
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ResultResponse<Point>>> Put(PostPointDto value)
        {
            if (!value.IsValid())
                return BadRequest("Invalida data!");

            try
            {
                return await ((PointService)_service).UpdateAsync(value.ToDomain());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete a existent register
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<Point>>> Delete(int id)
        {
            try
            {
                return await ((PointService)_service).DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}