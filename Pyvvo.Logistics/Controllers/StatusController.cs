using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class StatusController : Controller
    {
        private readonly ICoreStatus _coreStatus;
        public StatusController(ICoreStatus coreStatus)
        {
            _coreStatus= coreStatus;
        }

        [Authorize]
        [HttpGet("api/status-category/{statusCategoryId}/status")]
        public async Task<IActionResult> GetStatus(long statusCategoryId)
        {
            try
            {
                var status = await _coreStatus.GetAllStatus(statusCategoryId);
                if (status != null)
                    return Ok(status);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}