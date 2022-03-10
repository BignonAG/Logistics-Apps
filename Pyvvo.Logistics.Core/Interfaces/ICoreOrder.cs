using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreOrder 
    {
        Task<Boolean> Create(Order order, long userId);
        Task<List<Order>> GetOrders(long userId);
        Task<Order> Get(long Id);
        Task<Boolean> Update(Order order);
        Task<Boolean> Delete(long id);

    }
}