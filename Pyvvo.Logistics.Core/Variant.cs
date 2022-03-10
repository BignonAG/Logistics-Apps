using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;

namespace Pyvvo.Logistics.Core
{
    public class Variant:ICoreVariant
    {
        private readonly DatabaseContext _context;

        public Variant(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Model.Variant> Get(long id)
        {
            Model.Variant variant = null;
            try
            {
                variant = await _context.Variants
                    .Include(x => x.Status)
                    .Include(x => x.Options)
                    .Include(x => x.Parameter)
                    .Include(x => x.Product)
                    .Include(x => x.Taxe)
                    .Include(x => x.Image)
                    .Include(x => x.Supplier)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return variant;
        }

        public async Task<Boolean> Update(Model.Variant variant)
        {
            Boolean result = false;
            try
            {
                if (variant != null)
                {
                    variant.UpdatedOn = DateTime.Now;
                    if (variant.Status != null && variant.Status.Id != 0)
                        variant.StatusId = variant.Status.Id;
                    if (variant.Parameter != null && variant.Parameter.Id != 0)
                        variant.ParameterId = variant.Parameter.Id;
                    if (variant.Taxe != null && variant.Taxe.Id != 0)
                        variant.TaxeId = variant.Taxe.Id;
                    if (variant.Image != null && string.IsNullOrEmpty(variant.Image.PathUrl))
                        variant.ImageId = variant.Image.Id;
                    if (variant.Supplier != null && variant.Supplier.Id != 0)
                        variant.SupplierId = variant.Supplier.Id;

                    _context.Variants.Update(variant);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<bool> Delete(long id)
        {
            Boolean result = false;
            try
            {
                _context.Variants.Remove(await _context.Variants.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

    }
}
