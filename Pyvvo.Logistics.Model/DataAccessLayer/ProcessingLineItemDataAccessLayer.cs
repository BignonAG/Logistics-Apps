// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class ProcessingLineItemDataAccessLayer : DataAccessLayer<ProcessingLineItem>
//     {
//         public ProcessingLineItemDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<ProcessingLineItem>> GetEntities(Expression<Func<ProcessingLineItem, bool>> predicate)
//         {
//             List<ProcessingLineItem> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.ProcessingLineItems
//                     .Include(x => x.OrderLineItem)
//                     .Include(x => x.OrderLineItem.Variant)
//                     .Include(x => x.Status)
//                     .Include(x => x.OrderLineItem.Order)
//                     .Include(x => x.Processing)
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
