// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class InvoiceLineItemDataAccessLayer : DataAccessLayer<InvoiceLineItem>
//     {
//         public InvoiceLineItemDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<InvoiceLineItem>> GetEntities(Expression<Func<InvoiceLineItem, bool>> predicate)
//         {
//             List<InvoiceLineItem> items = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 items = await context.InvoiceLineItems
//                     .Include(x => x.OrderLineItem)
//                         .ThenInclude(x =>x.Variant)
//                         .ThenInclude(x =>x.Product)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.Createdon)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return items;
//         }
//     }
// }
