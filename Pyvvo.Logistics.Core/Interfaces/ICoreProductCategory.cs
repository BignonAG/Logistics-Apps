using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;


namespace Pyvvo.Logistics.Core
{
    public interface ICoreProductCategory
    {
        Task<ProductCategory> Get(long id);
        Task<List<ProductCategory>> GetEntities(long compagnyId);
    }
}