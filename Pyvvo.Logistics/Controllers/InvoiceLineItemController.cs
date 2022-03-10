using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class InvoiceLineItemController : Controller
    {
        private readonly ICoreInvoiceLineItem _coreInvoiceLineItem;
        public InvoiceLineItemController(ICoreInvoiceLineItem coreInvoiceLineItem)
        {
            _coreInvoiceLineItem = coreInvoiceLineItem;
        }

        [Authorize]
        [HttpGet("api/invoice/{invoiceId}/invoice-line-items")]
        public async Task<IActionResult> GetOrderLineItems(long invoiceId)
        {
            try
            {
                var invoiceLineItems = await _coreInvoiceLineItem.GetEntities(invoiceId);
                if (invoiceLineItems != null)
                    return Ok(invoiceLineItems);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}