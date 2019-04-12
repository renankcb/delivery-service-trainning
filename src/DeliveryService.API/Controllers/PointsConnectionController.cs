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
            _service = (PointsConnectionService)service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Return all registers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResultResponse<IEnumerable<PointsConnection>>>> Get()
        {
            try
            {
                return await ((PointsConnectionService)_service).GetAllAsync();
            }
            catch
            {
                return BadRequest("Error to retireve Data!");
            }
        }

        /// <summary>
        /// Return specific register by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Get(int id)
        {
            try
            {
                var result = await ((PointsConnectionService)_service).GetByIdAsync(id);
                if (result == null)
                    return NotFound();

                return result;
            }
            catch
            {
                return BadRequest("Error to retrieve register");
            }
        }

        /// <summary>
        /// Add a new register
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Post(PostPointsConnectionDto value)
        {
            if (!value.IsValid())
                return BadRequest("Invalida data!");

            try
            {
                return await ((PointsConnectionService)_service).SaveAsync(value.ToDomain());
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
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Put(PostPointsConnectionDto value)
        {
            if (!value.IsValid())
                return BadRequest("Invalida data!");

            try
            {
                return await ((PointsConnectionService)_service).UpdateAsync(value.ToDomain());
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
        public async Task<ActionResult<ResultResponse<PointsConnection>>> Delete(int id)
        {
            try
            {
                return await ((PointsConnectionService)_service).DeleteAsync(id);
            }
            catch
            {
                return BadRequest("Error to DeleteAsync register!");
            }
        }
    }
}