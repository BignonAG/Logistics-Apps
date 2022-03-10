using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly ICoreWarehouse _coreWarehouse;
        public WarehouseController(ICoreWarehouse coreWarehouse)
        {
            _coreWarehouse=coreWarehouse;
        }

        [Authorize]
        [HttpGet("api/user/warehouses")]
        public async Task<IActionResult> GetUserList()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var Warehouses = await _coreWarehouse.GetList(userId);
                    if (Warehouses != null)
                        return Ok(Warehouses);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/warehouses")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var Warehouses = await _coreWarehouse.GetList();
                if (Warehouses != null)
                    return Ok(Warehouses);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/warehouse/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var warehouse = await _coreWarehouse.Get(id);
                if (warehouse != null)
                    return Ok(warehouse);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/warehouse")]
        public async Task<IActionResult> Create([FromBody] Warehouse warehouse)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                long statusId = 3; //status by default // verified
                    if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreWarehouse.Create(warehouse,userId,statusId);
                    if (isCreated)
                        return Created("", warehouse);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/warehouse")]
        public async Task<IActionResult> Update([FromBody] Warehouse warehouse)
        {
            try
            {
                var isUpdated = await _coreWarehouse.Update(warehouse);
                if (isUpdated)
                    return Ok(warehouse);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/warehouse/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreWarehouse.Delete(id);
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
