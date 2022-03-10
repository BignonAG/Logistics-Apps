using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class InvoiceCore:ICoreInvoice
    {
        private readonly DatabaseContext _context;

        public InvoiceCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> Create(Order order, long userId)
        {
            Invoice invoice = new Invoice();
            Boolean result = false;
            try
            {
                if (order.Id != 0)
                {
                    Order _order = await _context.Orders.FindAsync(Convert.ToInt64(order.Id));
                    invoice.CreatedById = userId;
                    invoice.ReferenceNumberId = _order.ReferenceNumberId;
                    invoice.ReferenceNumber = "#INV" + invoice.ReferenceNumberId;
                    invoice.CreatedOn = invoice.UpdatedOn = DateTime.Now;
                    invoice.IsActive = true;
                    invoice.OrderId = order.Id;
                    foreach (var item in _order.OrderLineItems)
                    {
                        invoice.InvoiceLineItems.Add(
                            new Model.InvoiceLineItem()
                            {
                                Createdon = DateTime.Now,
                                Updatedon = DateTime.Now,
                                OrderlineItemId = item.Id,
                                LineNumber = item.LineNumber
                            }
                        );
                    }
                    _context.Invoices.Update(invoice);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        // public Invoice GetLast()
        // {
        //     return dal.GetEntities().Result.OrderByDescending(x => x.CreatedOn).FirstOrDefault();
        // }

        public async Task<List<Model.Invoice>> GetEntities(long userId)
        {
            List<Invoice> invoices = null;
            try
            {
                invoices = await _context.Invoices
                    .Include(x => x.InvoiceLineItems)
                    .Include(x => x.PaymentTerm)
                    .Include(x => x.Order).ThenInclude(x => x.Customer).ThenInclude(x => x.Contact)
                    .Include(x => x.Order.Currency)
                    .Where(x => x.CreatedBy.Id == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return invoices;
        }

        public async Task<Invoice> Get(long orderId, long userId)
        {
            Invoice invoice = null;
            try
            {
                invoice = await _context.Invoices
                .Include(x => x.InvoiceLineItems)
                .Include(x => x.PaymentTerm)
                .Include(x => x.Order).ThenInclude(x => x.BillingAddress)
                .Include(x => x.Order).ThenInclude(x => x.ShippingAddress)
                .Include(x => x.Order).ThenInclude(x => x.Customer).ThenInclude(x => x.Contact)
                .Include(x => x.Order).ThenInclude(x => x.Currency)
                .Include(x => x.Order).ThenInclude(x => x.PayementStatus)
                .Include(x => x.Order).ThenInclude(x => x.OrderLineItems)
                .Include(x => x.Order).ThenInclude(x => x.Taxe)
                .FirstOrDefaultAsync(x => x.OrderId == orderId && x.CreatedById == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return invoice;
        }

        public async Task<Invoice> Get(long Id)
        {
            Invoice result = null;
            try
            {
                result = await _context.Invoices.FindAsync(Convert.ToInt64(Id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<Boolean> Delete(long id)
        {
            Boolean result = false;
            try
            {
                _context.Invoices.Remove(await _context.Invoices.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
