// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class ProductCategoryDataAccessLayer : DataAccessLayer<ProductCategory>
//     {
//         public ProductCategoryDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<ProductCategory>> GetEntities(Expression<Func<ProductCategory, bool>> predicate)
//         {
//             List<ProductCategory> products = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 products = await context.ProductCategories
//                     .Include(x => x.CreatedBy)
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

//         public override async Task<ProductCategory> Get(object param)
//         {
//             ProductCategory productCategory = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 productCategory = await context.ProductCategories
//                     //.Include(x => x.CreatedBy)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return productCategory;
//         }
//     }
// }
