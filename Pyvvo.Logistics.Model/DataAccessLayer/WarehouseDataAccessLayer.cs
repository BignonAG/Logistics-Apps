// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class WarehouseDataAccessLayer : DataAccessLayer<Warehouse>
//     {
//         public WarehouseDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Warehouse>> GetEntities()
//         {
//             List<Warehouse> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.Warehouses
//                     .Include(a => a.Address)
//                     .Include(c => c.Contact)
//                     .Include(c => c.Contact.Status)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }


//         public override async Task<List<Warehouse>> GetEntities(Expression<Func<Warehouse, bool>> predicate)
//         {
//             List<Warehouse> warehouses = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 warehouses = await context.Warehouses
//                     .Include(x => x.Contact)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return warehouses;
//         }

//         public override async Task<Warehouse> Get(object param)
//         {
//             Warehouse warehouse = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 warehouse = await context.Warehouses
//                     .Include(a => a.Address)
//                     .Include(c => c.Contact)
//                     //.Include(c => c.Contact.Status)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return warehouse;
//         }

//         public override async Task<Model.Warehouse> GetEntityPredicate(Expression<Func<Warehouse, bool>> predicate)
//         {
//             Warehouse warehouse = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 warehouse = await context.Warehouses
//                     .Include(x => x.Contact)
//                     .Include(x => x.Address)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return warehouse;
//         }

//     }
// }
