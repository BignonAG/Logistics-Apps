// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;
// using System.Transactions;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class RefundDataAccessLayer : DataAccessLayer<Refund>
//     {
//         public RefundDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Refund>> GetEntities(Expression<Func<Refund, bool>> predicate)
//         {
//             List<Refund> refunds = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 refunds = await context.Refunds
//                     .Include(x => x.Order)
//                     .Include(x => x.Order.Currency)
//                     .Include(x => x.Status)
//                     .Include(x => x.RefundLineItems)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return refunds;
//         }

//         public override async Task<Refund> Get(object param)
//         {
//             Refund refund = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 refund = await context.Refunds
//                     .Include(x => x.Order)
//                     .Include(x => x.Order.Currency)
//                     .Include(x => x.Order.Customer)
//                     .Include(x => x.Order.Customer.Contact)
//                     .Include(x => x.Order.OrderLineItems)
//                     .Include(x => x.CreatedBy)
//                     .Include(c => c.Status)
//                     .Include(c => c.RefundLineItems)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//                 //context.Entry(refund).State = EntityState.Detached;
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return refund;
//         }

//         public override async Task<List<Refund>> GetEntities()
//         {
//             List<Refund> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.Refunds
//                     .Include(x => x.Order)
//                     .Include(c => c.Status)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }

//         public override async Task<Model.Refund> GetEntityPredicate(Expression<Func<Refund, bool>> predicate)
//         {
//             Refund refund = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 refund = await context.Refunds
//                     .Include(x => x.Order)
//                     .Include(c => c.Status)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return refund;
//         }

//         public async Task<bool> Update(Refund refund, List<RefundLineItem> oldItems)
//         {
//             bool result;
//             using DatabaseContext context = new DatabaseContext();
//             using var transaction = context.Database.BeginTransaction();
//             try
//             {

//                 context.RefundLineItems.RemoveRange(oldItems);
//                 result = await context.SaveChangesAsync() > 0;

//                 //context.Entry(refund).State = EntityState.Detached;
//                 //context.Entry(refund).State = EntityState.Modified;
//                 context.Refunds.Update(refund);
//                 result = await context.SaveChangesAsync() > 0; 

//                 transaction.Commit();
//                 return result;
//             }
//             catch (Exception ex)
//             {
//                 transaction.Rollback();
//                 throw new Exception(ex.Message);
//             }
//         }
//     }
// }
