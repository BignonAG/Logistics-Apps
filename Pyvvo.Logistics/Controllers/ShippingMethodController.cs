using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class ShippingMethodController : Controller
    {
        private readonly ICoreShippingMethod _coreShippingMethod;
        public ShippingMethodController(ICoreShippingMethod coreShippingMethod)
        {
            _coreShippingMethod=coreShippingMethod;
        }

        [Authorize]
        [HttpGet("api/shipping-methods")]
        public async Task<IActionResult> GetCurrencies()
        {
            try
            {
                var shippingMethods = await _coreShippingMethod.GetEntities();
                if (shippingMethods != null)
                    return Ok(shippingMethods);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}