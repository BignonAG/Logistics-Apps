using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class Return:ICoreReturn
    {
        private readonly DatabaseContext _context;
        public Return(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> Create(Model.Return _return, long userId)
        {
            Boolean result = false;
            try
            {
                if (_return != null)
                {
                    _return.ReferenceNumber = "#" + _return.Order.ReferenceNumberId;
                    _return.CreatedOn = _return.UpdatedOn = DateTime.Now;
                    _return.CreatedById = userId;
                    if (_return.Agent != null && _return.Agent.Id != 0)
                        _return.AgentId = _return.Agent.Id;
                    if (_return.Status != null)
                        _return.StatusId = _return.Status.Id;
                    if (_return.Order != null && _return.Order.Id != 0)
                    {
                        _return.OrderId = _return.Order.Id;
                        _return.Order.OrderLineItems = null;
                    }
                    if (_return.ReturnLineItems != null)
                    {
                        foreach (var item in _return.ReturnLineItems)
                        {
                            item.CreatedOn = item.UpdatedOn = DateTime.Now;
                        }
                    }
                    if (_return.Notes != null)
                    {
                        foreach (var item in _return.Notes)
                        {
                            item.CreatedOn = item.UpdatedOn = DateTime.Now;
                            item.CreatedById = userId;
                        }
                    }
                    _context.Returns.Update(_return);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Boolean> Update(Model.Return _return)
        {
            Boolean result = false;
            try
            {
                if (_return != null)
                {
                    _return.UpdatedOn = DateTime.Now;
                    if (_return.Agent != null && _return.Agent.Id != 0)
                        _return.AgentId = _return.Agent.Id;
                    if (_return.Status != null)
                        _return.StatusId = _return.Status.Id;
                    if (_return.Order != null && _return.Order.Id != 0)
                    {
                        _return.OrderId = _return.Order.Id;
                        _return.Order.OrderLineItems = null;
                    }
                    if (_return.ReturnLineItems != null)
                    {
                        foreach (var item in _return.ReturnLineItems)
                        {
                            item.UpdatedOn = DateTime.Now;
                            item.Return = null;
                            item.OrderLineItem.ReturnLineItems = null;
                        }
                    }
                    if (_return.Notes != null)
                    {
                        foreach (var item in _return.Notes)
                        {
                            item.UpdatedOn = DateTime.Now;
                        }
                    }
                    _context.Returns.Update(_return);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<List<Model.Return>> GetEntities(long userId)
        {
            List<Model.Return> returns = null;
            try
            {
                returns = await _context.Returns
                    .Include(x => x.Agent)
                    .Include(x => x.Order).ThenInclude(x => x.Currency)
                    .Include(x => x.ReturnLineItems)
                    .Include(x => x.Status)
                    .Where(x => x.CreatedById == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returns;
        }
        public async Task<Model.Return> Get(long Id)
        {
            Model.Return _return = null;
            try
            {
                _return = await _context.Returns
                     .Include(x => x.Agent)
                    .Include(x => x.Order)
                    .Include(x => x.ReturnLineItems)
                    .Include(x => x.Status)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(Id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _return;
        }
        public async Task<Boolean> Delete(long id)
        {
            Boolean result = false;
            try
            {
                _context.Returns.Remove(await _context.Returns.FindAsync(Convert.ToInt64(id)));
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
