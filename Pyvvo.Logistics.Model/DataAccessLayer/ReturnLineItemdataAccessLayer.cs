// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class ReturnLineItemdataAccessLayer : DataAccessLayer<ReturnLineItem>
//     {
//         public ReturnLineItemdataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<ReturnLineItem>> GetEntities(Expression<Func<ReturnLineItem, bool>> predicate)
//         {
//             List<ReturnLineItem> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.ReturnLineItems
//                     .Include(x => x.OrderLineItem)
//                     .Include(x => x.OrderLineItem.Variant)
//                     .Include(x => x.Status)
//                     .Include(x => x.OrderLineItem.Order)
//                     .Include(x => x.Return)
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
