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
    public class WarehouseCore : ICoreWarehouse
    {
        private readonly DatabaseContext _context;
        public WarehouseCore(DatabaseContext context)
        {
            _context = context;

        }

        public async Task<Boolean> Create(Warehouse warehouse, long userId, long statusId)
        {
            Boolean result = false;
            try
            {
                if (warehouse != null)
                {
                    if (warehouse.Contact != null)
                    {
                        if (warehouse.Contact.Status != null)
                            warehouse.Contact.StatusId = warehouse.Contact.Status.Id;
                        warehouse.Contact.CreateDon = warehouse.Contact.UpdateDon = DateTime.Now;
                    }

                    if (warehouse.Address != null)
                    {
                        warehouse.Address.Createdon = DateTime.Now;
                        warehouse.Address.CreatedById = userId;
                    }
                    warehouse.CreatedOn = DateTime.Now;
                    warehouse.UpdatedOn = DateTime.Now;
                    warehouse.IsActive = true;
                    warehouse.CreatedById = userId;
                    _context.Warehouses.Update(warehouse);
                    result = await _context.SaveChangesAsync() > 0;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Boolean> Update(Warehouse warehouse)
        {
            Boolean result = false;
            try
            {
                if (warehouse != null)
                {
                    var dbWarehouse = await Get(warehouse.Id);
                    if (dbWarehouse != null)
                    {
                        warehouse.IsActive = dbWarehouse.IsActive;
                        warehouse.CreatedOn = dbWarehouse.CreatedOn;
                        warehouse.UpdatedOn = DateTime.Now;
                        if (warehouse.Contact != null)
                        {
                            if (warehouse.Contact.Status != null)
                                warehouse.Contact.StatusId = warehouse.Contact.Status.Id;
                            warehouse.Contact.UpdateDon = DateTime.Now;
                            warehouse.Contact.IsActive = dbWarehouse.Contact.IsActive;
                            warehouse.Contact.CreateDon = dbWarehouse.Contact.CreateDon;
                        }

                        if (warehouse.Address != null)
                        {
                            warehouse.Address.Updatedon = DateTime.Now;
                            warehouse.Address.Createdon = dbWarehouse.Address.Createdon;
                        }
                    _context.Warehouses.Update(warehouse);
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
        public async Task<Boolean> Delete(long id)
        {
            Boolean result = false;
            try
            {
                _context.Warehouses.Remove(await _context.Warehouses.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<List<Warehouse>> GetList(long userId)
        {
              List<Warehouse> entities = null;
            try
            {
                entities = await _context.Warehouses
                    .Include(a => a.Address)
                    .Include(c => c.Contact)
                    .Include(c => c.Contact.Status)
                    .Where(x => x.CreatedBy.Id == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }
        public async Task<List<Warehouse>> GetList()
        {
            List<Warehouse> entities = null;
            try
            {
                entities = await _context.Warehouses
                    .Include(a => a.Address)
                    .Include(c => c.Contact)
                    .Include(c => c.Contact.Status)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }
        public async Task<Warehouse> Get(long id)
        {
            Warehouse warehouse = null;
            try
            {
                warehouse = await _context.Warehouses
                    .Include(a => a.Address)
                    .Include(c => c.Contact)
                    //.Include(c => c.Contact.Status)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return warehouse;
        }
    }
}
