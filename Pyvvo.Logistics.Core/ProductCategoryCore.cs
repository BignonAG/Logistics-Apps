using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class ProductCategoryCore:ICoreProductCategory
    {
        private readonly DatabaseContext _context;

        public ProductCategoryCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ProductCategory> Get(long id)
        {
            Model.ProductCategory productCategory = null;
            try
            {
                productCategory = await _context.ProductCategories
            .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productCategory;
        }
        public async Task<List<ProductCategory>> GetEntities(long compagnyId)
        {
            List<ProductCategory> productCategory = null;
            try
            {
                productCategory = await _context.ProductCategories
                    .Include(x => x.CreatedBy)
                    .Where(x => x.CreatedBy.Company.Id == compagnyId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productCategory;

        }

    }
}
