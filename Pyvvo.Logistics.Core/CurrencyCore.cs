using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class CurrencyCore :ICoreCurrency
    {
        private readonly DatabaseContext _context;

        public CurrencyCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Currency> Get(long Id)
        {
            Currency currency =null;
            try
            {
                currency =await _context.Currencies.FindAsync(Convert.ToInt64(Id));
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return currency;

        }

        public async Task<List<Currency>> GetEntities()
        {
            List<Currency> currency = null;
            try
            {
                currency = await _context.Currencies.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return currency;
        }
    }
}
