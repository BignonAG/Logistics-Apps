using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreShippingMethod
    {
        Task<ShippingMethod> Get(long Id);
        Task<List<ShippingMethod>> GetEntities();

    }
}