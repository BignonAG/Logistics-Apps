using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ICoreSupplier _coreSupplier;
        public SupplierController(ICoreSupplier coreSupplier)
        {
            _coreSupplier =coreSupplier;
        }

        [Authorize]
        [HttpGet("api/suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var suppliers = await _coreSupplier.GetSuppliers(userId);
                    if (suppliers != null)
                        return Ok(suppliers);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/supplier/{id}")]
        public async Task<IActionResult> GetSupplier(long id)
        {
            try
            {
                var supplier = await _coreSupplier.GetSupplier(id);
                if (supplier != null)
                    return Ok(supplier);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/supplier")]
        public async Task<IActionResult> Create([FromBody] Model.Supplier supplier)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreSupplier.CreateSupplier(supplier, userId);
                    if (isCreated)
                        return Created("", supplier);// return created status 200 when request is successfull;
                }
                
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/supplier")]
        public async Task<IActionResult> Update([FromBody] Model.Supplier supplier)
        {
            try
            {
                var isUpdated = await _coreSupplier.UpdateSupplier(supplier);
                if (isUpdated)
                    return Ok(supplier);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/supplier/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreSupplier.DeleteSupplier(id);
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