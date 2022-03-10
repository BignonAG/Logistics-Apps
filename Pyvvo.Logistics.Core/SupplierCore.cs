using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class SupplierCore:ICoreSupplier
    {
        private readonly DatabaseContext _context;

        public SupplierCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> CreateSupplier(Supplier supplier, long userId)
        {
            Boolean result = false;
            try
            {
                if (supplier != null)
                {
                    supplier.IsActive = true;
                    supplier.CreatedOn = supplier.UpdatedOn = DateTime.Now;
                    supplier.CreatedById = userId;
                    supplier.RefUser = new Model.User()
                    {
                        CreateDon = DateTime.Now,
                        UpdateDon = DateTime.Now,
                    };
                    if (supplier.Contact != null)
                    {
                        if (supplier.Contact.Status != null)
                            supplier.Contact.StatusId = supplier.Contact.Status.Id;
                        supplier.Contact.CreateDon = supplier.Contact.UpdateDon = DateTime.Now;
                    }
                    if (supplier.Address != null)
                    {
                        supplier.Address.Createdon = supplier.Address.Updatedon = DateTime.Now;
                        supplier.Address.CreatedBy = supplier.RefUser;
                    }
                    _context.Suppliers.Update(supplier);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }
        public async Task<Boolean> UpdateSupplier(Supplier supplier)
        {
            Boolean result = false;
            try
            {
                if (supplier != null)
                {
                    var dbSupplier = await GetSupplier(supplier.Id);
                    if (dbSupplier != null)
                    {
                        supplier.IsActive = dbSupplier.IsActive;
                        supplier.CreatedOn = dbSupplier.CreatedOn;
                        supplier.UpdatedOn = DateTime.Now;
                        if (supplier.Contact != null)
                        {
                            supplier.Contact.UpdateDon = DateTime.Now;
                            supplier.Contact.IsActive = dbSupplier.Contact.IsActive;
                            supplier.Contact.CreateDon = dbSupplier.Contact.CreateDon;
                        }
                        if (supplier.Address != null)
                        {
                            supplier.Address.Updatedon = DateTime.Now;
                            supplier.Address.Createdon = dbSupplier.Address.Createdon;
                        }
                    _context.Suppliers.Update(supplier);
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
        public async Task<Boolean> DeleteSupplier(long id)
        {
            Boolean result = false;
            try
            {
                _context.Suppliers.Remove(await _context.Suppliers.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<List<Supplier>> GetSuppliers(long userId)
        {
            List<Supplier> supplier = null;
            try
            {
                supplier = await _context.Suppliers
                    .Include(x => x.Contact)
                    .Where(x => x.CreatedBy.Id == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return supplier;
        }
        public async Task<Supplier> GetSupplier(long id)
        {
            Supplier supplier = null;
            try
            {
                supplier = await _context.Suppliers
                    .Include(a => a.Address)
                    .Include(c => c.Contact)
                    .Include(c => c.Contact.Status)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return supplier;
        }
    }
}
