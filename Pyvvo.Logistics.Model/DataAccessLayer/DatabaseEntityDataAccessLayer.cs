using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{

    public class DatabaseEntityDataAccessLayer : DataAccessLayer<DatabaseEntity>
    {
        public DatabaseEntityDataAccessLayer(DatabaseContext context) : base(context)
        {
        }
    }

}
