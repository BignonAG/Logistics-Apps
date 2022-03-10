using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class AccountLoginDataAccessLayer: DataAccessLayer<AccountLogin>
    {
        private  DatabaseContext _context;

        public AccountLoginDataAccessLayer(DatabaseContext context) : base(context)
        {
            
        }

        public override async Task<Model.AccountLogin> GetEntityPredicate(Expression<Func<AccountLogin, bool>> predicate)
        {
            AccountLogin account = null;
            try
            {
                account = await _context.AccountLogins
                    .Include(x => x.User).ThenInclude(x => x.Company)
                    .FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }
    }
}
