using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICoreCurrency _coreCurrency;
        public CurrencyController(ICoreCurrency coreCurrency )
        {
            _coreCurrency = coreCurrency;
        }

        [Authorize]
        [HttpGet("api/currencies")]
        public async Task<IActionResult> GetCurrencies()
        {
            try
            {
                var currencies = await _coreCurrency.GetEntities();
                if (currencies != null)
                    return Ok(currencies);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}