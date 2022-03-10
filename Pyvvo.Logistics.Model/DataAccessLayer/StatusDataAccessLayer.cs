// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class StatusDataAccessLayer : DataAccessLayer<Status>
//     {
//         public StatusDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<Status> Get(object param)
//         {
//             Status entity = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entity = await context.Status
//                     .Include(x => x.StatusCategory)
//                     .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entity;
//         }
//     }
// }
