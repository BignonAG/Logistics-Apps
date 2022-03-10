// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class ReturnDataAccessLayer : DataAccessLayer<Return>
//     {
//         public ReturnDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Model.Return>> GetEntities(Expression<Func<Model.Return, bool>> predicate)
//         {
//             List<Model.Return> returns = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 returns = await context.Returns
//                     .Include(x => x.Agent)
//                     .Include(x => x.Order).ThenInclude(x => x.Currency)
//                     .Include(x => x.ReturnLineItems)
//                     .Include(x => x.Status)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return returns;
//         }

//         public override async Task<Model.Return> Get(object param)
//         {
//             Model.Return _return = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 _return = await context.Returns
//                      .Include(x => x.Agent)
//                     .Include(x => x.Order)
//                     .Include(x => x.ReturnLineItems)
//                     .Include(x => x.Status)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return _return;
//         }

//         public override async Task<List<Model.Return>> GetEntities()
//         {
//             List<Model.Return> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.Returns
//                .Include(x => x.Agent)
//                     .Include(x => x.Order)
//                     .Include(x => x.ReturnLineItems)
//                     .Include(x => x.Status)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }

//         public override async Task<Model.Return> GetEntityPredicate(Expression<Func<Model.Return, bool>> predicate)
//         {
//             Model.Return _return = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 _return = await context.Returns
//                      .Include(x => x.Agent)
//                     .Include(x => x.Order)
//                     .Include(x => x.ReturnLineItems)
//                     .Include(x => x.Status)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return _return;
//         }
//     }
// }
