using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreUploader
    {
         Task<List<Uri>> GetBlobs();
         Task<Uri> GetBlob(string filename);
         Task<Uri> UploadBlob(IFormFile file,long userId);
         Task<bool> DeleteBlob(string filename);

    }
}