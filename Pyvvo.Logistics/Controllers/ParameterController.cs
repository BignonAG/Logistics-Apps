using System;
using Pyvvo.Logistics.Core;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pyvvo.Logistics.Controllers
{
    public class ParameterController : Controller
    {
        private readonly ICoreParameter _coreParameter;
        public ParameterController(ICoreParameter coreParameter)
        {
            _coreParameter =coreParameter;
        }

        [Authorize]
        [HttpGet("api/parameters")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value;
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var parameters = await _coreParameter.GetEntities(userId);
                    if (parameters != null)
                        return Ok(parameters);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}