// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class SupplierDataAccessLayer: DataAccessLayer<Supplier>
//     {
//         public SupplierDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Model.Supplier>> GetEntities(Expression<Func<Supplier, bool>> predicate)
//         {
//             List<Supplier> suppliers = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 suppliers = await context.Suppliers
//                     .Include(x => x.Contact)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return suppliers;
//         }

//         public override async Task<Supplier> Get(object param)
//         {
//             Supplier supplier = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 supplier = await context.Suppliers
//                     .Include(a => a.Address)
//                     .Include(c => c.Contact)
//                     .Include(c => c.Contact.Status)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return supplier;
//         }

//         public override async Task<Model.Supplier> GetEntityPredicate(Expression<Func<Supplier, bool>> predicate)
//         {
//             Supplier supplier = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 supplier = await context.Suppliers
//                     .Include(x => x.Contact)
//                     .Include(x => x.Address)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return supplier;
//         }
//     }
// }
