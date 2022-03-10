using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICoreCustomer _coreCustomer;
        public CustomerController(ICoreCustomer coreCustomer)
        {
            _coreCustomer = coreCustomer;
        }

        [Authorize]
        [HttpGet("api/customers")]
        public async Task<IActionResult> GetCutomers()
        {
            try
            {
                var customers = await _coreCustomer.GetCustomers(1);
                if (customers != null)
                    return Ok(customers);
                return BadRequest();
            }
            catch (Exception ex)    
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/user/customers")]
        public async Task<IActionResult> GetUserCutomers()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var customers = await _coreCustomer.GetCustomers(userId);
                    if (customers != null)
                        return Ok(customers);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/customer/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var customer = await _coreCustomer.GetCustomer(id);
                if (customer != null)
                    return Ok(customer);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/customer")]
        public async Task<IActionResult> Create([FromBody] Model.Customer customer)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreCustomer.CreateCustomer(customer, userId);
                    if (isCreated)
                        return Created("", customer);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/customer")]
        public async Task<IActionResult> Update([FromBody] Model.Customer customer)
        {
            try
            {
                var isUpdated = await _coreCustomer.UpdateCustomer(customer);
                if (isUpdated)
                    return Ok(customer);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/customer/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreCustomer.DeleteCustomer(id);
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