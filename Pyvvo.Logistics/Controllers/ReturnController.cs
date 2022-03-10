using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class ReturnController : Controller
    {
        private readonly ICoreReturn _coreReturn;
        public ReturnController( ICoreReturn coreReturn)
        {
            _coreReturn=coreReturn;
        }

        [Authorize]
        [HttpGet("api/returns")]
        public async Task<IActionResult> GetReturns()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var _returns = await _coreReturn.GetEntities(userId);
                    if (_returns != null)
                        return Ok(_returns);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/returns/{id}")]
        public async Task<IActionResult> GetReturn(long id)
        {
            try
            {
                var _return = await _coreReturn.Get(id);
                if (_return != null)
                    return Ok(_return);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/returns")]
        public async Task<IActionResult> Create([FromBody] Model.Return _return)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreReturn.Create(_return, userId);
                    if (isCreated)
                        return Created("", _return);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/returns")]
        public async Task<IActionResult> Update([FromBody] Model.Return _return)
        {
            try
            {
                var isUpdated = await _coreReturn.Update(_return);
                if (isUpdated)
                    return Ok(_return);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/returns/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreReturn.Delete(id);
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