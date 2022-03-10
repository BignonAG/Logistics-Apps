using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class VariantController : Controller
    {
        private readonly ICoreVariant _coreVariant;
        public VariantController(ICoreVariant coreVariant)
        {
            _coreVariant=coreVariant;
        }

        [Authorize]
        [HttpGet("api/variant/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {

                var variant = await _coreVariant.Get(id);
                if (variant != null)
                    return Ok(variant);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/variant")]
        public async Task<IActionResult> Update([FromBody] Model.Variant variant)
        {
            try
            {

                var isUpdated = await _coreVariant.Update(variant);
                if (isUpdated)
                    return Ok(variant);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/variant/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {

                var isDeleted = await _coreVariant.Delete(id);
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