// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class UserDataAccessLayer : DataAccessLayer<User>
//     {
//         public UserDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Model.User>> GetEntities(Expression<Func<User, bool>> predicate)
//         {
//             List<User> users = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 users = await context.Users
//                     .Include(x => x.Contact)
//                     .Where(predicate)
//                     .OrderByDescending(x => x.CreateDon)
//                     .ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return users;
//         }

//         public override async Task<User> Get(object param)
//         {
//             User user = null;
//             try
//             {
//                 using (DatabaseContext context = new DatabaseContext())
//                 {
//                     user = await context.Users
//                       .Include(c => c.Contact)
//                       .Include(c => c.Status)
//                       .Include(c => c.Company)
//                       .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//                 }
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return user;
//         }

//         public async Task<User> GetLite(object param)
//         {
//             User user = null;
//             try
//             {
//                 using (DatabaseContext context = new DatabaseContext())
//                 {
//                     user = await context.Users
//                       .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
//                 }
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return user;
//         }

//         public override async Task<Model.User> GetEntityPredicate(Expression<Func<User, bool>> predicate)
//         {
//             User user = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 user = await context.Users
//                     .Include(x => x.Contact)
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
