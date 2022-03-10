using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;

namespace Pyvvo.Logistics.Core
{
    public class RefundLineItemCore:ICoreRefundLineItem
    {
        private readonly DatabaseContext _context;
        public RefundLineItemCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<RefundLineItem>> GetEntities(long refundId)
        {
            List<RefundLineItem> entities = null;
            try
            {

                entities = await _context.RefundLineItems
                    .Include(x => x.OrderLineItem)
                    .Include(x => x.OrderLineItem.Variant)
                    .Include(x => x.Status)
                    .Include(x => x.OrderLineItem.Order)
                    .Include(x => x.Refund)
                    .Where(x => x.RefundId == refundId)
                    .ToListAsync(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }
    }
}
