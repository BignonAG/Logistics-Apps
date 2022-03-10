using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreProduct
    {
        Task<Boolean> Create(Product product, long userId);
        Task<Boolean> Update(Product product);
        Task<Boolean> Delete(long id);
        Task<List<Product>> GetEntities(long userId);
        Task<Product> Get(long id);
    }
}