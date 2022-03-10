using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class ProductCore : ICoreProduct
    {
        private readonly DatabaseContext _context;

        public ProductCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> Create(Product product, long userId)
        {
            Boolean result = false;
            try
            {
                if (product != null)
                {
                    product.CreatedOn = product.UpdatedOn = DateTime.Now;
                    product.CreatedById = userId;
                    if (product.Status != null)
                        product.StatusId = product.Status.Id;
                    if (product.ProductCategory != null)
                        product.ProductCategoryId = product.ProductCategory.Id;
                    if (product.Variants != null && product.Variants.Count > 0)
                    {
                        foreach (var item in product.Variants)
                        {
                            item.CreatedOn = item.UpdatedOn = DateTime.Now;
                            item.Options = product.Options.Where(x => !string.IsNullOrEmpty(x.Name)).ToList();
                            foreach (var option in item.Options)
                            {
                                option.CreatedOn = DateTime.Now;
                            }
                            //if (product.Taxe != null && product.Taxe.Id !=0)
                            //    item.Taxe = await new TaxeCore().Get(product.Taxe.Id);
                        }
                    }
                    product.Options = null;
                    if (product.Image != null)
                    {
                        //product.Image.CreatedBy = user;
                        product.Image.CreatedOn = product.Image.UpdatedOn = DateTime.Now;
                    }
                    if (product.Taxe != null && product.Taxe.Id != 0)
                        product.TaxeId = product.Taxe.Id;
                    _context.Products.Update(product);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<Boolean> Update(Product product)
        {
            Boolean result = false;
            try
            {
                if (product != null)
                {
                    var dbproduct = await Get(product.Id);
                    product.CreatedOn = dbproduct.CreatedOn;
                    product.UpdatedOn = DateTime.Now;
                    if (product.Image != null)
                        product.ImageId = product.Image.Id;
                    if (product.Status != null)
                        product.StatusId = product.Status.Id;
                    if (product.ProductCategory != null)
                        product.ProductCategoryId = product.ProductCategory.Id;
                    if (product.Taxe != null && product.Taxe.Id != 0)
                        product.TaxeId = product.Taxe.Id;
                    if (product.Variants != null && product.Variants.Count > 0)
                    {
                        foreach (var item in product.Variants)
                        {
                            item.UpdatedOn = DateTime.Now;
                        }
                    }
                        _context.Products.Update(product);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<Boolean> Delete(long id)
        {
            Boolean result = false;
            try
            {
                _context.Products.Remove(await _context.Products.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<List<Product>> GetEntities(long userId)
        {
             List<Model.Product> products = null;
            try
            {

                products = await _context.Products
                    .Include(x => x.ProductCategory)
                    .Include(x => x.Variants)
                    .Include(x => x.Status)
                    .Include(x => x.Image)
                    .Where(x => x.CreatedById == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public async Task<Product> Get(long id)
        {
            Product product = null;
            try
            {
                product = await _context.Products
                    .Include(x => x.ProductCategory)
                    .Include(x => x.Variants)
                    .Include(x => x.Status)
                    .Include(x => x.Taxe)
                    .Include(x => x.Options)
                    .Include(x => x.Image)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }


    }
}
