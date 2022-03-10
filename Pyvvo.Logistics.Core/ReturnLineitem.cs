using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class ReturnLineItem:ICoreReturnLineItem
    {
        private readonly DatabaseContext _context;
        public ReturnLineItem(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Model.ReturnLineItem>> GetEntities(long returnId)
        {
            List<Model.ReturnLineItem> entities = null;
            try
            {
                entities = await _context.ReturnLineItems
                    .Include(x => x.OrderLineItem)
                    .Include(x => x.OrderLineItem.Variant)
                    .Include(x => x.Status)
                    .Include(x => x.OrderLineItem.Order)
                    .Include(x => x.Return)
                    .Where(x => x.Return.Id == returnId)
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
