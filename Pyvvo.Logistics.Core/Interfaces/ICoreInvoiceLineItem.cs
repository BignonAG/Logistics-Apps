using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreInvoiceLineItem
    {
        Task<List<InvoiceLineItem>> GetEntities(long invoiceId);
    }
}