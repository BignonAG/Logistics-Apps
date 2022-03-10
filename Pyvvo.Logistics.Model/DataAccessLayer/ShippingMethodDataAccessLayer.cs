using System;
using System.Collections.Generic;
using System.Text;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class ShippingMethodDataAccessLayer : DataAccessLayer<ShippingMethod>
    {
        public ShippingMethodDataAccessLayer(DatabaseContext context) : base(context)
        {
        }
    }
}
