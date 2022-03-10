// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Text;
// using System.Threading.Tasks;

// namespace Pyvvo.Logistics.Model.DataAccessLayer
// {
//     public class TaxeDataAccessLayer : DataAccessLayer<Taxe>
//     {
//         public TaxeDataAccessLayer(DatabaseContext context) : base(context)
//         {
//         }

//         public override async Task<List<Taxe>> GetEntities()
//         {
//             List<Taxe> entities = null;
//             try
//             {
//                 using DatabaseContext context = new DatabaseContext();
//                 entities = await context.Taxes.Include(x => x.TaxLineItems).ToListAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.Message);
//             }
//             return entities;
//         }
//     }
// }
