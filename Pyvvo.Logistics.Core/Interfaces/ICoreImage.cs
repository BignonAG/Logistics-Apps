using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface IcoreImage
    {
        Task<Model.Image> Get(string filename);
        Task<Model.Image> GetByUrl(string url);
        Task<List<Model.Image>> GetEntities(long userId);
        Task<Boolean> Create(Model.Image image, long userId);
        Task<Boolean> Delete(string filename);
    }
}