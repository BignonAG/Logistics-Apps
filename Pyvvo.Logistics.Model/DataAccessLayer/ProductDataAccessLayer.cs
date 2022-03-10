// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class ProductDataAccessLayer : DataAccessLayer<Product>
//     {
//         public ProductDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Product>> GetEntities(Expression<Func<Product, bool>> predicate)
//         {
//             List<Product> products = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 products = await context.Products
//                     .Include(x => x.ProductCategory)
//                     .Include(x => x.Variants)
//                     .Include(x => x.Status)
//                     .Include(x => x.Image)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return products;
//         }

//         public override async Task<Product> Get(object param)
//         {
//             Product product = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 product = await context.Products
//                     .Include(x => x.ProductCategory)
//                     .Include(x => x.Variants)
//                     .Include(x => x.Status)
//                     .Include(x => x.Taxe)
//                     .Include(x => x.Options)
//                     .Include(x => x.Image)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return product;
//         }

//         public override async Task<List<Product>> GetEntities()
//         {
//             List<Product> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.Products
//                     .Include(x => x.ProductCategory)
//                     .Include(x => x.Variants)
//                     .Include(x => x.Status)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }

//         public override async Task<Model.Product> GetEntityPredicate(Expression<Func<Product, bool>> predicate)
//         {
//             Product product = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 product = await context.Products
//                     .Include(x => x.ProductCategory)
//                     .Include(x => x.Variants)
//                     .Include(x => x.Status)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return product;
//         }
//     }
// }
