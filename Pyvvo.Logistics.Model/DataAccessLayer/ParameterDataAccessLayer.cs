// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class ParameterDataAccessLayer: DataAccessLayer<Parameter>
//     {
//         public ParameterDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Parameter>> GetEntities(Expression<Func<Parameter, bool>> predicate)
//         {
//             List<Parameter> parameters = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 parameters = await context.Parameters
//                     .Include(x => x.WeightUnit)
//                     .Include(x => x.DimensionUnit)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreatedOn)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return parameters;
//         }

//         public override async Task<Parameter> Get(object param)
//         {
//             Parameter parameter = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 parameter = await context.Parameters
//                     .Include(x => x.WeightUnit)
//                     .Include(x => x.DimensionUnit)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return parameter;
//         }

//         public override async Task<List<Parameter>> GetEntities()
//         {
//             List<Parameter> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.Parameters
//                     .Include(x => x.WeightUnit)
//                     .Include(x => x.DimensionUnit)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }

//         public override async Task<Model.Parameter> GetEntityPredicate(Expression<Func<Parameter, bool>> predicate)
//         {
//             Parameter parameter = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 parameter = await context.Parameters
//                     .Include(x => x.WeightUnit)
//                     .Include(x => x.DimensionUnit)
//                     .FirstOrDefaultAsync(predicate);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return parameter;
//         }
//     }
// }
