using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class Parameter:ICoreParameter
    {
        private readonly DatabaseContext _context;
        public Parameter(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Model.Parameter> Get(long id)
        {
            Model.Parameter result = null;
            try
            {
                result = await _context.Parameters.FindAsync(Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<List<Model.Parameter>> GetEntities(long userId)
        {
           List<Model.Parameter> parameters = null;
            try
            {
                parameters = await _context.Parameters
                    .Include(x => x.WeightUnit)
                    .Include(x => x.DimensionUnit)
                    .Where(x => x.CreatedById == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return parameters;
        }
    }
}
