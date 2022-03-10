// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class OrderLineItemDataAccessLayer: DataAccessLayer<OrderLineItem>
//     {
//         public OrderLineItemDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<OrderLineItem>> GetEntities(Expression<Func<OrderLineItem, bool>> predicate)
//         {
//             List<OrderLineItem> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.OrderLineItems
//                     .Include(x => x.Variant)
//                     .Include(x => x.Order)
//                     .Where(predicate)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }

//         public override async Task<OrderLineItem> GetEntityPredicate(Expression<Func<OrderLineItem, bool>> predicate)
//         {
//             OrderLineItem entity = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entity = await context.OrderLineItems
//                     .Include(x => x.Variant)
//                     .Include(x => x.Order).FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entity;
//         }
//     }
// }
