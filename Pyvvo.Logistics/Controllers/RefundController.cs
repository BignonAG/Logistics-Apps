using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class RefundController : Controller
    {
        private readonly ICoreRefund _coreRefund;
        public RefundController(ICoreRefund coreRefund)
        {
            _coreRefund =coreRefund;
        }

        [Authorize]
        [HttpGet("api/refunds")]
        public async Task<IActionResult> GetRefunds()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var refunds = await _coreRefund.GetEntities(userId);
                    if (refunds != null)
                        return Ok(refunds);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/refund/{id}")]
        public async Task<IActionResult> GetRefund(long id)
        {
            try
            {
                var refund = await _coreRefund.Get(id);
                if (refund != null)
                    return Ok(refund);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/refund")]
        public async Task<IActionResult> Create([FromBody] Model.Refund refund)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreRefund.Create(refund, userId);
                    if (isCreated)
                        return Created("", refund);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/refund")]
        public async Task<IActionResult> Update([FromBody] Model.Refund refund)
        {
            try
            {
                var isUpdated = await _coreRefund.Update(refund);
                if (isUpdated)
                    return Ok(refund);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/refund/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreRefund.Delete(id);
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