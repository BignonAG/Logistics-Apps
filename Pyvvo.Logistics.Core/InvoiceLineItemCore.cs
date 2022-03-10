using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class InvoiceLineItemCore
    {
        private readonly DatabaseContext _context;

        public InvoiceLineItemCore(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<InvoiceLineItem>> GetEntities(long invoiceId)
        {
            List<InvoiceLineItem> items = null;
            try
            {
                items = await _context.InvoiceLineItems
                    .Include(x => x.OrderLineItem)
                        .ThenInclude(x => x.Variant)
                        .ThenInclude(x => x.Product)
                    .Where(x => x.Invoice.Id == invoiceId)
                    .OrderByDescending(x => x.Createdon)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return items;
        }
    }
}
