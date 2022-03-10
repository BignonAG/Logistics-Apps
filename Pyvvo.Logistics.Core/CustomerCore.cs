using Pyvvo.Logistics.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pyvvo.Logistics.Core
{
    public class CustomerCore:ICoreCustomer
    {
        private readonly DatabaseContext _context;
        public CustomerCore(DatabaseContext context)
        {
            _context = context;

        }

        public async Task<Boolean> CreateCustomer(Customer customer, long userId)
        {
            Boolean result = false;
            try
            {
                if (customer != null)
                {
                    if (customer.BillingAddress != null)
                    {
                        customer.BillingAddress.Createdon = DateTime.Now;
                        customer.BillingAddress.CreatedById = userId;
                    }
                    if (customer.ShippingAddress != null)
                    {
                        customer.ShippingAddress.Createdon = DateTime.Now;
                        customer.ShippingAddress.CreatedById = userId;
                    }
                    if (customer.Contact != null)
                    {
                        customer.Contact.CreateDon = DateTime.Now;
                        customer.Contact.StatusId = customer.Status.Id;
                    }
                    customer.StatusId = customer.Status.Id;
                    customer.CreatedOn = customer.UpdatedOn = DateTime.Now;
                    customer.CreatedById = userId;
                    customer.IsActive = true;
                    _context.Update(customer);
                    result = await _context.SaveChangesAsync() > 0;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public async Task<Boolean> UpdateCustomer(Customer customer)
        {
            Boolean result = false;
            try
            {
                if (customer != null)
                {

                    bool customerExist = await _context.Customers.FindAsync(Convert.ToInt64(customer.Id)) != null;
                    if (customerExist && customer.Contact != null &&
                     customer.BillingAddress != null && customer.ShippingAddress != null)
                    {
                        customer.UpdatedOn = DateTime.Now;
                        _context.Customers.Update(customer);
                        result = await _context.SaveChangesAsync() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public async Task<Boolean> DeleteCustomer(long id)
        {
            var result = false;
            try
            {
                _context.Customers.Remove(await _context.Customers.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<List<Model.Customer>> GetCustomers(long userId)
        {
            List<Customer> customers = null;
            try
            {
                customers = await _context.Customers.Include(x => x.Contact)
                    .Where(x => x.CreatedBy.Id == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        // public async Task<List<Model.Customer>> GetCustomers()
        // {
        //     return await dal.GetEntities();
        // }

        public async Task<Model.Customer> GetCustomer(long id)
        {
            Customer customer = null;
            try
            {
                customer = await _context.Customers.FindAsync(Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
    }
}
