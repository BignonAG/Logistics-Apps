using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pyvvo.Logistics.Core;

namespace Pyvvo.Logistics.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ICoreUploader _coreUploader;
        private readonly IcoreImage _coreImage;
        public GalleryController(ICoreUploader coreUploader,IcoreImage coreImage)
        {
            _coreUploader = coreUploader;
            _coreImage =coreImage;
        }

        [Authorize]
        [HttpPost("api/blob")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var request = await HttpContext.Request.ReadFormAsync();
                    var file = request.Files[0];
                    var uri = await _coreUploader.UploadBlob(file, userId);
                    return Ok(new { uri });
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/medias")]
        public async Task<IActionResult> GetMedias()
        {
            try
            {
                string storeId = User.Claims.First(c => c.Type == "userId").Value; // Get stored user id when user sign in or sign up
                if (!string.IsNullOrEmpty(storeId))
                {
                    var userId = Convert.ToInt64(storeId);
                    var images = await _coreImage.GetEntities(userId);
                    return Ok(images);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/blobs")]
        public async Task<IActionResult> GetBlobs()
        {
            try
            {
                var blobUris = await _coreUploader.GetBlobs();
                return Ok(blobUris);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/blob/{filename}")]
        public async Task<IActionResult> GetBlob(string filename)
        {
            try
            {
                var uri = await _coreUploader.GetBlob(filename);
                return Ok(new { uri });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("api/blob/{filename}")]
        public async Task<IActionResult> DeleteBlob(string filename)
        {
            try
            {
                var isDeleted = await _coreUploader.DeleteBlob(filename);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}