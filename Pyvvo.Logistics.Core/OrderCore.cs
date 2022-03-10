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
    public class OrderCore: ICoreOrder
    {
        private readonly DatabaseContext _context;
        public OrderCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> Create(Order order, long userId)
        {
            Boolean result = false;
            try
            {
                if (order != null)
                {
                    order.CreatedById = userId;
                    var lastOrder = await GetLast();
                    order.CreatedOn = order.UpdatedOn = DateTime.Now;
                    if (lastOrder == null)
                        order.ReferenceNumberId = 1001;
                    else
                        order.ReferenceNumberId = lastOrder.ReferenceNumberId + 1;
                    order.ReferenceNumber = "#" + order.ReferenceNumberId;
                    if (order.BillingAddress != null)
                    {
                        order.BillingAddress.Createdon = DateTime.Now;
                        order.BillingAddress.CreatedById = userId;
                    }
                    if (order.ShippingAddress != null)
                    {
                        order.ShippingAddress.Createdon = DateTime.Now;
                        order.ShippingAddress.CreatedById = userId;
                    }
                    if (order.Status != null)
                        order.StatusId = order.Status.Id;
                    if (order.PayementStatus != null)
                        order.PayementStatusId = order.PayementStatus.Id;
                    if (order.FulfillmentStatus != null)
                        order.FulfillmentStatusId = order.FulfillmentStatus.Id;
                    if (order.Taxe != null)
                        order.TaxeId = order.Taxe.Id;
                    if (order.Currency != null)
                        order.CurrencyId = order.Currency.Id;
                    if (order.Customer != null)
                        order.CustomerId = order.Customer.Id;
                    if (order.Warehouse != null)
                        order.WarehouseId = order.Warehouse.Id;
                    if (order.ShippingMethod != null)
                        order.ShippingMethodId = order.ShippingMethod.Id;
                    if (order.OrderLineItems != null && order.OrderLineItems.Count > 0)
                    {
                        foreach (var item in order.OrderLineItems)
                        {
                            item.CreatedOn = item.UpdatedOn = DateTime.Now;
                            //item.FulfillmentSatus = order.FulfillmentStatus;
                        }
                    }
                    _context.Update(order);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<List<Order>> GetOrders(long userId)
        {
            List<Order> orders = null;
            try
            {
                orders = await _context.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.Customer.Contact)
                    .Include(x => x.Currency)
                    .Include(x => x.PayementStatus)
                    .Include(x => x.FulfillmentStatus)
                    .Include(x => x.Status)
                    .Include(x => x.CreatedBy)
                    .Include(x => x.OrderLineItems)
                    .Where(x => x.CreatedBy.Id == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public async Task<Order> Get(long Id)
        {
            Order result = null;
            try
            {
                result = await _context.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.Customer.Contact)
                    .Include(x => x.Taxe)
                    .Include(x => x.Taxe.TaxLineItems)
                    .Include(x => x.FulfillmentStatus)
                    .Include(x => x.Status)
                    .Include(x => x.CreatedBy)
                    .Include(x => x.Currency)
                    .Include(x => x.Warehouse)
                    .Include(x => x.Shippings)
                    .Include(x => x.BillingAddress)
                    .Include(x => x.ShippingAddress)
                    .Include(x => x.ShippingMethod)
                    .Include(x => x.ShippingMethod.CarrierService)
                    .Include(x => x.PayementStatus)
                    .Include(x => x.Invoices)
                    .Include(x => x.Refunds)
                    .Include(x => x.Returns)
                    .Include(x => x.OrderLineItems)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(Id));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Order> GetLite(long Id)
        {
            Order result = null;
            try
            {
                result = await _context.Orders.Include(x => x.OrderLineItems).FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(Id));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Order> GetLast()
        {
            List<Order> Entities = null;
            Order result = null;
            try
            {
                Entities = await _context.Orders.ToListAsync();
                result = Entities.OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Boolean> Update(Order order)
        {
            Boolean result = false;
            try
            {
                if (order != null)
                {
                    var dbOrder = await Get(order.Id);
                    if (dbOrder != null)
                    {
                        order.CreatedOn = dbOrder.CreatedOn;
                        order.UpdatedOn = DateTime.Now;
                    }
                    if (order.BillingAddress != null)
                    {
                        order.BillingAddress.Updatedon = DateTime.Now;
                        order.BillingAddress.Createdon = dbOrder.BillingAddress.Createdon;
                    }
                    if (order.ShippingAddress != null)
                    {
                        order.ShippingAddress.Updatedon = DateTime.Now;
                        order.ShippingAddress.Createdon = dbOrder.BillingAddress.Createdon;
                    }
                    if (order.Status != null)
                        order.StatusId = order.Status.Id;
                    if (order.PayementStatus != null)
                        order.PayementStatusId = order.PayementStatus.Id;
                    if (order.FulfillmentStatus != null)
                        order.FulfillmentStatusId = order.FulfillmentStatus.Id;
                    if (order.Taxe != null)
                        order.TaxeId = order.Taxe.Id;
                    if (order.Currency != null)
                        order.CurrencyId = order.Currency.Id;
                    if (order.Customer != null)
                        order.CustomerId = order.Customer.Id;
                    if (order.Warehouse != null)
                        order.WarehouseId = order.Warehouse.Id;
                    if (order.ShippingMethod != null)
                        order.ShippingMethodId = order.ShippingMethod.Id;
                    if (order.OrderLineItems != null && order.OrderLineItems.Count > 0)
                    {
                        foreach (var item in order.OrderLineItems)
                        {
                            var dbLineItem = await new OrderLineItemCore(_context).Get(order.Id, item.Variant.Id);
                            item.UpdatedOn = DateTime.Now;
                            item.CreatedOn = dbLineItem.CreatedOn;
                            item.Id = dbLineItem.Id;
                        }
                    }
                    _context.Update(order);
                    result = await _context.SaveChangesAsync() > 0;
                }
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
                _context.Orders.Remove(await _context.Orders.FindAsync(Convert.ToInt64(id)));
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
