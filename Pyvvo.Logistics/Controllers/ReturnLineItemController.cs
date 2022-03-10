using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class ReturnLineItemController : Controller
    {
        private readonly ICoreReturnLineItem _coreReturnLineItem;
        public ReturnLineItemController(ICoreReturnLineItem coreReturnLineItem)
        {
            _coreReturnLineItem = coreReturnLineItem;
        }

        [Authorize]
        [HttpGet("api/return/{returnId}/return-line-items")]
        public async Task<IActionResult> GetReturnLineItems(long returnId)
        {
            try
            {
                var returnLineItems = await _coreReturnLineItem.GetEntities(returnId);
                if (returnLineItems != null)
                    return Ok(returnLineItems);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}