using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreOrderLineItem
    {
        Task<List<OrderLineItem>> GetEntities(long orderId);
        Task<OrderLineItem> Get(long orderId, long variantId);

    }
}