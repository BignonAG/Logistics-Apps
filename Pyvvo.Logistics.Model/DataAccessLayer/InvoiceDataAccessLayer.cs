// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class InvoiceDataAccessLayer : DataAccessLayer<Invoice>
//     {
//         public InvoiceDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Invoice>> GetEntities(Expression<Func<Invoice, bool>> predicate)
//         {
//             List<Invoice> invoices = null;
//             try
//             {
//                 invoices = await context.Invoices
//                     .Include(x => x.InvoiceLineItems)
//                     .Include(x => x.PaymentTerm)
//                     .Include(x => x.Order).ThenInclude(x => x.Customer).ThenInclude(x => x.Contact)
//                     .Include(x => x.Order.Currency)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return invoices;
//         }

//         public override async Task<Invoice> Get(object param)
//         {
//             Invoice invoice = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 invoice = await context.Invoices
//                     .Include(x => x.InvoiceLineItems)
//                     .Include(x => x.PaymentTerm)
//                     .Include(x => x.Order)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return invoice;
//         }

//         public override async Task<Invoice> GetEntityPredicate(Expression<Func<Invoice, bool>> predicate)
//         {
//             Invoice customer = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 customer = await context.Invoices
//                     .Include(x => x.InvoiceLineItems)
//                     .Include(x => x.PaymentTerm)
//                     .Include(x => x.Order).ThenInclude(x => x.BillingAddress)
//                     .Include(x => x.Order).ThenInclude(x => x.ShippingAddress)
//                     .Include(x => x.Order).ThenInclude(x => x.Customer).ThenInclude(x => x.Contact)
//                     .Include(x => x.Order).ThenInclude(x => x.Currency)
//                     .Include(x => x.Order).ThenInclude(x => x.PayementStatus)
//                     .Include(x => x.Order).ThenInclude(x => x.OrderLineItems)
//                     .Include(x => x.Order).ThenInclude(x => x.Taxe)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return customer;
//         }
//     }
// }
