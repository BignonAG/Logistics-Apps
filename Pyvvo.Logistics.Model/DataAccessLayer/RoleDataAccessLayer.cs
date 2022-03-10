using System;
using System.Collections.Generic;
using System.Text;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class RoleDataAccessLayer : DataAccessLayer<Role>
    {
        public RoleDataAccessLayer(DatabaseContext context) : base(context)
        {
        }
    }
}
