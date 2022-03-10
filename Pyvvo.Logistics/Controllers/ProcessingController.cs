using System;
using System.Collections.Generic;
using Pyvvo.Logistics.Core;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pyvvo.Logistics.Controllers
{
    public class ProcessingController : Controller
    {
        private readonly ICoreProcessing _coreProcessing;
        public ProcessingController(ICoreProcessing coreProcessing)
        {
            _coreProcessing = coreProcessing;
        }

        [Authorize]
        [HttpGet("api/processings")]
        public async Task<IActionResult> GetProcessings()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var processings = await _coreProcessing.GetEntities(userId);
                    if (processings != null)
                        return Ok(processings);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/processing/{id}")]
        public async Task<IActionResult> GetProcessing(long id)
        {
            try
            {
                var processing = await _coreProcessing.Get(id);
                if (processing != null)
                    return Ok(processing);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/processing")]
        public async Task<IActionResult> Create([FromBody] Model.Processing processing)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreProcessing.Create(processing, userId);
                    if (isCreated)
                        return Created("", processing);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/processing")]
        public async Task<IActionResult> Update([FromBody] Model.Processing processing)
        {
            try
            {
                var isUpdated = await _coreProcessing.Update(processing);
                if (isUpdated)
                    return Ok(processing);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/processing/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreProcessing.Delete(id);
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