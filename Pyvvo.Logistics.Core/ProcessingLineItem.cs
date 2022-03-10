using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class ProcessingLineItem: ICoreProcessingLineItem
    {
        private readonly DatabaseContext _context;
        public ProcessingLineItem(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Model.ProcessingLineItem>> GetEntities(long processingId)
        {
            List<Model.ProcessingLineItem> entities = null;
            try
            {
                entities = await  _context.ProcessingLineItems
                    .Include(x => x.OrderLineItem)
                    .Include(x => x.OrderLineItem.Variant)
                    .Include(x => x.Status)
                    .Include(x => x.OrderLineItem.Order)
                    .Include(x => x.Processing)
                    .Where(x => x.Processing.Id == processingId)
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
