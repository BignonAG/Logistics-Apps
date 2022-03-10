using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class UserController : Controller
    {
        private readonly ICoreUser _coreUser;
        public UserController(ICoreUser coreUser)
        {
            _coreUser= coreUser;
        }

        [Authorize]
        [HttpGet("api/users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var users = await _coreUser.GetUsers(userId);
                    if (users != null)
                        return Ok(users);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/user/{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            try
            {
                var user = await _coreUser.GetUser(id);
                if (user != null)
                    return Ok(user);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/user")]
        public async Task<IActionResult> Create([FromBody] Model.User user)
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                long roleId = 1; //role by default // verified
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var isCreated = await _coreUser.CreateUser(user, userId, roleId);
                    if (isCreated)
                        return Created("", user);// return created status 200 when request is successfull;
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("api/user")]
        public async Task<IActionResult> Update([FromBody] Model.User user)
        {
            try
            {

                var isUpdated = await _coreUser.UpdateUser(user);
                if (isUpdated)
                    return Ok(user);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/user/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _coreUser.DeleteUser(id);
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