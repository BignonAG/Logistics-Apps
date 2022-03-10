using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class RoleCore:ICoreRole
    {
        private readonly DatabaseContext _context;

        public RoleCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRole(long id)
        {
            Role result = null;
            try
            {
                result = await _context.Roles.FindAsync(Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
