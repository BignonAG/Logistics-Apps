using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;
using Pyvvo.Logistics.Model;

namespace Pyvvo.Logistics.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICoreProduct _coreProduct;
        public ProductController(ICoreProduct coreProduct)
        {
            _coreProduct = coreProduct;
        }

        [Authorize]
        [HttpGet("api/products")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var products = await _coreProduct.GetEntities(userId);
                    if (products != null)
                        return Ok(products);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/product/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var product = await _coreProduct.Get(id);
                if (product != null)
                    return Ok(product);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/product")]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreProduct.Create(product, userId);
                    if (isCreated)
                        return Created("", product);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/product")]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            try
            {
                var isUpdated = await _coreProduct.Update(product);
                if (isUpdated)
                    return Ok(product);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/product/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreProduct.Delete(id);
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