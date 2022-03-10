using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class CustomerDataAccessLayer: DataAccessLayer<Customer>
    {
        private DatabaseContext _context;

        public CustomerDataAccessLayer(DatabaseContext context) : base(context)
        {
        }

        public override async Task<List<Model.Customer>> GetEntities(Expression<Func<Customer, bool>> predicate)
        {
            List<Customer> customers = null;
            try
            {
                
                customers = await _context.Customers
                    .Include(x => x.Contact)
                    .Where(predicate)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public override async Task<Customer> Get(object param)
        {
            Customer customer = null;
            try
            {
                
                customer = await _context.Customers
                    .Include(a => a.ShippingAddress)
                    .Include(a => a.BillingAddress)
                    .Include(c => c.Contact)
                    .Include(c => c.Status)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public override async Task<List<Customer>> GetEntities()
        {
            List<Customer> entities = null;
            try
            {
                
                entities = await _context.Customers
                    .Include(a => a.ShippingAddress)
                    .Include(a => a.BillingAddress)
                    .Include(c => c.Contact)
                    .Include(c => c.Status)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }

        public override async Task<Model.Customer> GetEntityPredicate(Expression<Func<Customer, bool>> predicate)
        {
            Customer customer = null;
            try
            {
                customer = await _context.Customers
                    .Include(x => x.Contact)
                     .Include(a => a.ShippingAddress)
                    .Include(a => a.BillingAddress)
                    .FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
    }
}
