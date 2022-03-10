// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class VariantDataAccessLayer : DataAccessLayer<Variant>
//     {
//         public VariantDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Variant>> GetEntities(Expression<Func<Variant, bool>> predicate)
//         {
//             List<Variant> variants = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 variants = await context.Variants
//                     .Include(x => x.Status)
//                     .Include(x => x.Product)
//                     .Include(x => x.Taxe)
//                     .Include(x => x.Image)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return variants;
//         }

//         public override async Task<Variant> Get(object param)
//         {
//             Variant variant = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 variant = await context.Variants
//                     .Include(x => x.Status)
//                     .Include(x => x.Options)
//                     .Include(x => x.Parameter)
//                     .Include(x => x.Product)
//                     .Include(x => x.Taxe)
//                     .Include(x => x.Image)
//                     .Include(x => x.Supplier)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return variant;
//         }

//         public override async Task<List<Variant>> GetEntities()
//         {
//             List<Variant> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.Variants
//                     .Include(x => x.Status)
//                     .Include(x => x.Product)
//                     .Include(x => x.Taxe)
//                     .Include(x => x.Image)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }

//         public override async Task<Model.Variant> GetEntityPredicate(Expression<Func<Variant, bool>> predicate)
//         {
//             Variant variant = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 variant = await context.Variants
//                     .Include(x => x.Status)
//                     .Include(x => x.Options)
//                     .Include(x => x.Parameter)
//                     .Include(x => x.Product)
//                     .Include(x => x.Taxe)
//                     .Include(x => x.Image)
//                     .Include(x => x.Supplier)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return variant;
//         }
//     }
// }
