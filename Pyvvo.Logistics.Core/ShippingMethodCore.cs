using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class ShippingMethodCore:ICoreShippingMethod
    {
        private readonly DatabaseContext _context;

        public ShippingMethodCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ShippingMethod> Get(long Id)
        {
            ShippingMethod result = null;
            try
            {
                result = await _context.ShippingMethods.FindAsync(Convert.ToInt64(Id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<List<ShippingMethod>> GetEntities()
        {
            List<ShippingMethod> entities = null;
            try
            {
                entities = await _context.ShippingMethods.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }
    }
}
