using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class RefundLineItemController : Controller
    {
        private readonly ICoreRefundLineItem _coreRefundLineItem;
        public RefundLineItemController(ICoreRefundLineItem coreRefundLineItem)
        {
            _coreRefundLineItem= coreRefundLineItem;
        }

        [Authorize]
        [HttpGet("api/refund/{refundId}/refund-line-items")]
        public async Task<IActionResult> GetRefundLineItems(long refundId)
        {
            try
            {

                var refundLineItems = await _coreRefundLineItem.GetEntities(refundId);
                if (refundLineItems != null)
                    return Ok(refundLineItems);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}