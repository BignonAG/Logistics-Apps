using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class AuthController : Controller
    {
        private ICoreTenant _tenantCore;
        private ICoreAccountLogin _accountLoginCore;
        public AuthController(ICoreTenant tenantcore, ICoreAccountLogin accountLoginCore)
        {
            _tenantCore = tenantcore;
            _accountLoginCore = accountLoginCore;
        }

        [HttpPost("api/auth/sign-up")]
        public async Task<IActionResult> SignUp([FromBody] AccountLogin accountLogin)
        {
            try
            {
                var token = await _accountLoginCore.SignUp(accountLogin);
                if (token != null)
                {
                    accountLogin.Token = token;
                    return Created("", accountLogin);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("api/auth/sign-test")]
        public async Task<IActionResult> Signtest([FromBody] Tenant tenant)
        {
            try
            {
                var result = await _tenantCore.Create(tenant);
                if (result != false)
                {
                    return Created("", tenant);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("api/auth/sign-in")]
        public async Task<IActionResult> SignIn([FromBody] AccountLogin accountLogin)
        {
            try
            {
                var dbAccount = await _accountLoginCore.SignIn(accountLogin);
                if (dbAccount != null)
                    return Ok(dbAccount);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}