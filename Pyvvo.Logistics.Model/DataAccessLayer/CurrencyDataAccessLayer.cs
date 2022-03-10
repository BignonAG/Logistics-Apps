using System;
using System.Collections.Generic;
using System.Text;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class CurrencyDataAccessLayer : DataAccessLayer<Currency>
    {
        public CurrencyDataAccessLayer(DatabaseContext context) : base(context)
        {
        }
    }
}
