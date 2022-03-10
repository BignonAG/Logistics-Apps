using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreReturn
    {
        Task<Boolean> Create(Model.Return _return, long userId);
        Task<Boolean> Update(Model.Return _return);
        Task<List<Model.Return>> GetEntities(long userId);
        Task<Model.Return> Get(long Id);
        Task<Boolean> Delete(long id);
    }
}