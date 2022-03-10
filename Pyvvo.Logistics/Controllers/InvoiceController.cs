using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ICoreInvoice _coreInvoice;
        public InvoiceController(ICoreInvoice coreInvoice)
        {
            _coreInvoice = coreInvoice; 
        }

        [Authorize]
        [HttpGet("api/invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var invoices = await _coreInvoice.GetEntities(userId);
                    if (invoices != null)
                        return Ok(invoices);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/order/{orderId}/invoice")]
        public async Task<IActionResult> GetInvoice(long orderId)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var invoice = await _coreInvoice.Get(orderId,userId);
                    if (invoice != null)
                        return Ok(invoice);
                }
                    
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/invoice")]
        public async Task<IActionResult> Create([FromBody] Model.Order order)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreInvoice.Create(order, userId);
                    if (isCreated)
                        return Created("", true);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        //[HttpPut("api/invoice")]
        //public async Task<IActionResult> Update([FromBody] Model.Invoice invoice)
        //{
        //    try
        //    {
        //        var _coreInvoice = new InvoiceCore();
        //        var isUpdated = await _coreInvoice.Update(invoice);
        //        if (isUpdated)
        //            return Ok(invoice);
        //        return BadRequest();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [Authorize]
        [HttpDelete("api/invoice/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreInvoice.Delete(id);
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