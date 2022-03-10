using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class TaxeController : Controller
    {
        private readonly ICoreTaxe _coreTaxe;
        public TaxeController(ICoreTaxe coreTaxe)
        {
            _coreTaxe=coreTaxe;
        }

        [Authorize]
        [HttpGet("api/taxes")]
        public async Task<IActionResult> GetTaxes()
        {
            try
            {
                var taxes = await _coreTaxe.GetEntities();
                if (taxes != null)
                    return Ok(taxes);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}