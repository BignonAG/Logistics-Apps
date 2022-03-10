using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class OrderLineItemCore:ICoreOrderLineItem
    {
        private readonly DatabaseContext _context;

        public OrderLineItemCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<OrderLineItem>> GetEntities(long orderId)
        {
            List<OrderLineItem> entities = null;
            try
            {
                entities = await _context.OrderLineItems
                    .Include(x => x.Variant)
                    .Include(x => x.Order)
                    .Where(x => x.Order.Id == orderId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }
        public async Task<OrderLineItem> Get(long orderId, long variantId)
        {
            OrderLineItem entity = null;
            try
            {

                entity = await _context.OrderLineItems
                    .Include(x => x.Variant)
                    .Include(x => x.Order).FirstOrDefaultAsync(x => x.Order.Id == orderId && x.Variant.Id == variantId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }
    }
}
