using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreRefund
    {
        Task<Boolean> Create(Model.Refund refund, long userId);
        Task<Boolean> Update(Model.Refund refund);
        Task<List<Model.Refund>> GetEntities(long userId);
        Task<Model.Refund> Get(long Id);
        Task<Boolean> Delete(long id);

    }
}