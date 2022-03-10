using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class TaxeCore : ICoreTaxe
    {
        private readonly DatabaseContext _context;

        public TaxeCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Taxe> Get(long Id)
        {
            Taxe result = null;
            try
            {
                result = await _context.Taxes.FindAsync(Convert.ToInt64(Id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<List<Taxe>> GetEntities()
        {
            List<Taxe> entities = null;
            try
            {
                entities = await _context.Taxes.Include(x => x.TaxLineItems).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }
    }
}
