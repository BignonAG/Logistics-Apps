// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class RefundLineItemDataAccessLayer : DataAccessLayer<RefundLineItem>
//     {
//         public RefundLineItemDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<RefundLineItem>> GetEntities(Expression<Func<RefundLineItem, bool>> predicate)
//         {
//             List<RefundLineItem> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.RefundLineItems
//                     .Include(x => x.OrderLineItem)
//                     .Include(x => x.OrderLineItem.Variant)
//                     .Include(x => x.Status)
//                     .Include(x => x.OrderLineItem.Order)
//                     .Include(x => x.Refund)
//                     .Where(predicate)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }
//     }
// }
