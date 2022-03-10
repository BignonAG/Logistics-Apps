using System;
using System.Collections.Generic;
using System.Text;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class TenantDataAccessLayer : DataAccessLayer<Tenant>
    {
        public TenantDataAccessLayer(DatabaseContext context) : base(context)
        {
        }
    }
}
