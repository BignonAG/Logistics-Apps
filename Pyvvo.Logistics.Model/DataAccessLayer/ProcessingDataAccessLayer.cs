// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class ProcessingDataAccessLayer : DataAccessLayer<Model.Processing>
//     {
//         public ProcessingDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Model.Processing>> GetEntities(Expression<Func<Model.Processing, bool>> predicate)
//         {
//             List<Model.Processing> processings = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 processings = await context.Processings
//                     .Include(x => x.Agent)
//                     .Include(x => x.Order).ThenInclude(x => x.Currency)
//                     .Include(x => x.ProcessingLineItems)
//                     .Include(x => x.Status)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return processings;
//         }

//         public override async Task<Model.Processing> Get(object param)
//         {
//             Model.Processing processing = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 processing = await context.Processings
//                      .Include(x => x.Agent)
//                     .Include(x => x.Order)
//                     .Include(x => x.ProcessingLineItems)
//                     .Include(x => x.Status)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return processing;
//         }

//         public override async Task<List<Model.Processing>> GetEntities()
//         {
//             List<Model.Processing> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.Processings
//                .Include(x => x.Agent)
//                     .Include(x => x.Order)
//                     .Include(x => x.ProcessingLineItems)
//                     .Include(x => x.Status)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }

//         public override async Task<Model.Processing> GetEntityPredicate(Expression<Func<Model.Processing, bool>> predicate)
//         {
//             Model.Processing processing = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 processing = await context.Processings
//                      .Include(x => x.Agent)
//                     .Include(x => x.Order)
//                     .Include(x => x.ProcessingLineItems)
//                     .Include(x => x.Status)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return processing;
//         }
//     }
// }
