using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class RefundCore:ICoreRefund
    {
        private readonly DatabaseContext _context;

        public RefundCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> Create(Model.Refund refund, long userId)
        {
            Boolean result = false;
            try
            {
                if (refund != null)
                {
                    refund.ReferenceNumber = "#R" + refund.Order.ReferenceNumberId;
                    refund.CreatedOn = refund.RefundedOn = refund.UpdatedOn = DateTime.Now;
                    refund.CreatedById = userId;
                    if (refund.Status != null)
                        refund.StatusId = refund.Status.Id;
                    refund.Order = refund.RefundLineItems.FirstOrDefault().OrderLineItem.Order;
                    refund.Order.OrderLineItems = null;
                    foreach (var item in refund.RefundLineItems)
                    {
                        item.CreatedOn = item.UpdatedOn = DateTime.Now;
                        item.OrderLineItem.Order = null;
                    }
                    _context.Refunds.Update(refund);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Boolean> Update(Model.Refund refund)
        {
            Boolean result = false;
            try
            {
                if (refund != null)
                {
                    var dbRefund = await Get(refund.Id);
                    if (dbRefund != null)
                    {
                        refund.CreatedOn = dbRefund.CreatedOn;
                        refund.RefundedOn = dbRefund.RefundedOn;
                        refund.ReferenceNumber = dbRefund.ReferenceNumber;
                        refund.ReferenceNumberId = dbRefund.ReferenceNumberId;
                        refund.CreatedBy = dbRefund.CreatedBy;
                    }
                    if (refund.Status != null)
                        refund.StatusId = refund.Status.Id;
                    refund.Order = refund.RefundLineItems.FirstOrDefault().OrderLineItem.Order;
                    refund.Order.OrderLineItems = null;
                    foreach (var item in refund.RefundLineItems)
                    {
                        item.UpdatedOn = DateTime.Now;
                        item.OrderLineItem.Order = null;
                    }
                    _context.RefundLineItems.RemoveRange(dbRefund.RefundLineItems);
                    result = await _context.SaveChangesAsync() > 0;
                    _context.Refunds.Update(refund);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<List<Model.Refund>> GetEntities(long userId)
        {
            List<Refund> entities = null;
            try
            {
                entities = await _context.Refunds
                    .Include(x => x.Order)
                    .Include(c => c.Status)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }
        public async Task<Model.Refund> Get(long Id)
        {
            Refund refund = null;
            try
            {
                refund = await _context.Refunds
                    .Include(x => x.Order)
                    .Include(x => x.Order.Currency)
                    .Include(x => x.Order.Customer)
                    .Include(x => x.Order.Customer.Contact)
                    .Include(x => x.Order.OrderLineItems)
                    .Include(x => x.CreatedBy)
                    .Include(c => c.Status)
                    .Include(c => c.RefundLineItems)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(Id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return refund;
        }
        public async Task<Boolean> Delete(long id)
        {
              Boolean result = false;
            try
            {
                _context.Refunds.Remove(await _context.Refunds.FindAsync(Convert.ToInt64(id)));
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
