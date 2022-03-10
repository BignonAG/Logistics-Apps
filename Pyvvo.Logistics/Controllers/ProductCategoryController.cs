using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ICoreProductCategory _coreProductCategory;
        public ProductCategoryController(ICoreProductCategory coreProductCategory)
        {
            _coreProductCategory =coreProductCategory;
        }

        [Authorize]
        [HttpGet("api/company/{companyId}/product-categories")]
        public async Task<IActionResult> GetCategories(long companyId)
        {
            try
            {
                var categories = await _coreProductCategory.GetEntities(companyId);
                if (categories != null)
                    return Ok(categories);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}