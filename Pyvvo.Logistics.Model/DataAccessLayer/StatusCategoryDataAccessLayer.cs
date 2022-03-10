using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class StatusCategoryDataAccessLayer : DataAccessLayer<StatusCategory>
    {
        public StatusCategoryDataAccessLayer(DatabaseContext context) : base(context)
        {
        }
    }
}
