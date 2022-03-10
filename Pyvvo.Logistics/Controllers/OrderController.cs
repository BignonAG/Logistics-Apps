using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICoreOrder _coreOrder;
        public OrderController(ICoreOrder coreOrder)
        {
            _coreOrder = coreOrder;
        }

        [Authorize]
        [HttpGet("api/orders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var orders = await _coreOrder.GetOrders(userId);
                    if (orders != null)
                        return Ok(orders);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/order/{id}")]
        public async Task<IActionResult> GetOrder(long id)
        {
            try
            {
                var order = await _coreOrder.Get(id);
                if (order != null)
                    return Ok(order);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/order")]
        public async Task<IActionResult> Create([FromBody] Model.Order order)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreOrder.Create(order, userId);
                    if (isCreated)
                        return Created("", order);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/order")]
        public async Task<IActionResult> Update([FromBody] Model.Order order)
        {
            try
            {
                var isUpdated = await _coreOrder.Update(order);
                if (isUpdated)
                    return Ok(order);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/order/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreOrder.Delete(id);
                if (isDeleted)
                    return NoContent();
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}