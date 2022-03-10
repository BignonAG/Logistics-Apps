using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreInvoice 
    {
        Task<Boolean> Create(Order order, long userId);
        Task<List<Model.Invoice>> GetEntities(long userId);
        Task<Invoice> Get(long orderId, long userId);
        Task<Invoice> Get(long Id);
        Task<Boolean> Delete(long id);

    }
}