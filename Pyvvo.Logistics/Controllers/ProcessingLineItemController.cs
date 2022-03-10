using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class ProcessingLineItemController : Controller
    {
        private  readonly ICoreProcessingLineItem _coreProcessingLineItem;
        public ProcessingLineItemController(ICoreProcessingLineItem coreProcessingLineItem)
        {
            _coreProcessingLineItem = coreProcessingLineItem;
        }

        [Authorize]
        [HttpGet("api/processing/{processingId}/processing-line-items")]
        public async Task<IActionResult> GetProcessingLineItems(long processingId)
        {
            try
            {
                var processingLineItems = await _coreProcessingLineItem.GetEntities(processingId);
                if (processingLineItems != null)
                    return Ok(processingLineItems);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}