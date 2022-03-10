using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class OrderLineItemController : Controller
    {
        private readonly ICoreOrderLineItem _coreOrderlineitem;
        public OrderLineItemController(ICoreOrderLineItem coreOrderlineitem)
        {
            _coreOrderlineitem = coreOrderlineitem;
        }

        [Authorize]
        [HttpGet("api/order/{orderId}/order-line-items")]
        public async Task<IActionResult> GetOrderLineItems(long orderId)
        {
            try
            {
                var orderLineItems = await _coreOrderlineitem.GetEntities(orderId);
                if (orderLineItems != null)
                    return Ok(orderLineItems);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}