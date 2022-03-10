// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class OrderDataAccessLayer : DataAccessLayer<Order>
//     {
//         public OrderDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Order>> GetEntities(Expression<Func<Order, bool>> predicate)
//         {
//             List<Order> orders = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 orders = await context.Orders
//                     .Include(x => x.Customer)
//                     .Include(x => x.Customer.Contact)
//                     .Include(x => x.Currency)
//                     .Include(x => x.PayementStatus)
//                     .Include(x => x.FulfillmentStatus)
//                     .Include(x => x.Status)
//                     .Include(x => x.CreatedBy)
//                     .Include(x => x.OrderLineItems)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return orders;
//         }

//         public override async Task<Order> Get(object param)
//         {
//             Order order = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 order = await context.Orders
//                     .Include(x => x.Customer)
//                     .Include(x => x.Customer.Contact)
//                     .Include(x => x.Taxe)
//                     .Include(x => x.Taxe.TaxLineItems)
//                     .Include(x => x.FulfillmentStatus)
//                     .Include(x => x.Status)
//                     .Include(x => x.CreatedBy)
//                     .Include(x => x.Currency)
//                     .Include(x => x.Warehouse)
//                     .Include(x => x.Shippings)
//                     .Include(x => x.BillingAddress)
//                     .Include(x => x.ShippingAddress)
//                     .Include(x => x.ShippingMethod)
//                     .Include(x => x.ShippingMethod.CarrierService)
//                     .Include(x => x.PayementStatus)
//                     .Include(x => x.Invoices)
//                     .Include(x => x.Refunds)
//                     .Include(x => x.Returns)
//                     .Include(x => x.OrderLineItems)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
                
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
            
//             return order;
//         }

//         public async Task<Order> GetLite(object param)
//         {
//             Order user = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 user = await context.Orders.Include(x=>x.OrderLineItems).FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return user;
//         }

//         public override async Task<Model.Order> GetEntityPredicate(Expression<Func<Order, bool>> predicate)
//         {
//             Order user = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 user = await context.Orders
//                     .Include(x => x.Customer)
//                     .Include(x => x.FulfillmentStatus)
//                     .Include(x => x.Status)
//                     .Include(x => x.CreatedBy)
//                     .Include(x => x.Currency)
//                     .Include(x => x.Warehouse)
//                     .Include(x => x.Shippings)
//                     .Include(x => x.BillingAddress)
//                     .Include(x => x.Shippings)
//                     .Include(x => x.Invoices)
//                     .Include(x => x.Refunds)
//                     .Include(x => x.Returns)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return user;
//         }

//     }
// }
