using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;


namespace Pyvvo.Logistics.Core
{
    public interface ICoreRefundLineItem
    {
        Task<List<RefundLineItem>> GetEntities(long refundId);
    }
}