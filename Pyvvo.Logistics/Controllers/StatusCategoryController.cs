using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;
using Pyvvo.Logistics.Model;

namespace Pyvvo.Logistics.Controllers
{
    public class StatusCategoryController : Controller
    {
        private readonly ICoreStatusCategory _coreStatusCategory;
        public StatusCategoryController(ICoreStatusCategory coreStatusCategory)
        {
            _coreStatusCategory = coreStatusCategory;
        }

        [Authorize]
        [HttpPost("api/status/category")]
        public async Task<IActionResult> Create([FromBody] StatusCategory statusCategory)
        {
            try
            {
                var isCreated = await _coreStatusCategory.AddOrdUpdate(statusCategory);
                if (isCreated)
                    return Created("", statusCategory);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
            return BadRequest();
        }
    }
}