using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class TenantCore : ICoreTenant
    {
        private  DatabaseContext _context;
        public TenantCore(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Boolean> Create(Tenant tenant)
        {
            Boolean result = false;
            try
            {
                if (tenant != null && tenant.BillingAddress != null && tenant.ShippingAddress != null && tenant.Contact != null)
                {
                    tenant.CreatedOn = tenant.UpdatedOn = DateTime.Now;
                    tenant.BillingAddress.Createdon = tenant.BillingAddress.Updatedon = DateTime.Now;
                    tenant.ShippingAddress.Createdon = tenant.ShippingAddress.Updatedon = DateTime.Now;
                    tenant.Contact.CreateDon = tenant.Contact.UpdateDon = DateTime.Now;
                    _context.Tenants.Update(tenant);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result ;

        }
        public async Task<Boolean> Update(Tenant tenant)
        {
            Boolean result = false;
            try
            {

                if (tenant != null && tenant.BillingAddress != null && tenant.ShippingAddress != null && tenant.Contact != null
                && tenant.Status != null)
                {
                    tenant.UpdatedOn = DateTime.Now;
                    _context.Tenants.Update(tenant);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result ;
        }
        public async Task<Boolean> Delete(long id)
        {
            Boolean result = false;
            try
            {
                _context.Tenants.Remove(await _context.Tenants.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Tenant> Get(long id)
        {
            Tenant result = null;
            try
            {
                result = await _context.Tenants.FindAsync(Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<List<Tenant>> GetList(Expression<Func<Tenant, bool>> predicate, string QueryParam)
        {
            List<Tenant> result = null;
            try
            {
                if (QueryParam.Contains(";") || QueryParam.Contains(","))
                {
                    Type entity = new Tenant().GetType();
                    QueryParam = QueryParam.Replace(";", ",");
                    string[] tempincludes = QueryParam.Split(",").Length < 50 ? QueryParam.Split(",") : null;
                    List<string> includes = null;
                    var context = _context.Tenants;

                    foreach (PropertyInfo pInfo in entity.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                    {
                        foreach (string item in tempincludes)
                        {
                            if (pInfo.Name == item)
                                includes.Add(pInfo.Name);
                        }
                    }
                    foreach (string include in includes)
                    {
                        context = (DbSet<Tenant>)context.Include(include);
                    }
                    result = await context.Where(predicate)
                        .OrderByDescending(x => x.CreatedOn)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }

    }
}