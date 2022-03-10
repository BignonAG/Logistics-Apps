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
    public class Processing:ICoreProcessing
    {
        private readonly DatabaseContext _context;
        public Processing(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> Create(Model.Processing processing, long userId)
        {
            Boolean result = false;
            try
            {
                if (processing != null)
                {
                    var lastProcessing = await GetLast();
                    if (lastProcessing == null)
                        processing.ReferenceNumberId = 1001;
                    else
                        processing.ReferenceNumberId = lastProcessing.ReferenceNumberId + 1;
                    processing.ReferenceNumber = "#" + processing.ReferenceNumberId;
                    processing.CreatedOn = processing.UpdatedOn = DateTime.Now;
                    processing.CreatedById = userId;
                    if (processing.Agent != null && processing.Agent.Id != 0)
                        processing.AgentId = processing.Agent.Id;
                    if (processing.Status != null)
                        processing.StatusId = processing.Status.Id;
                    if (processing.Order != null && processing.Order.Id != 0)
                        processing.OrderId = processing.Order.Id;
                    if (processing.ProcessingLineItems != null)
                    {
                        foreach (var item in processing.ProcessingLineItems)
                        {
                            item.CreatedOn = item.UpdatedOn = DateTime.Now;
                        }
                    }
                    if (processing.Notes != null)
                    {
                        foreach (var item in processing.Notes)
                        {
                            item.CreatedOn = item.UpdatedOn = DateTime.Now;
                            item.CreatedById = userId;
                        }
                    }
                    _context.Update(processing);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Boolean> Update(Model.Processing processing)
        {
            Boolean result = false;
            try
            {
                if (processing != null)
                {
                    processing.UpdatedOn = DateTime.Now;
                    if (processing.Agent != null && processing.Agent.Id != 0)
                        processing.AgentId = processing.Agent.Id;
                    if (processing.Status != null)
                        processing.StatusId = processing.Status.Id;
                    if (processing.Order != null && processing.Order.Id != 0)
                        processing.OrderId = processing.Order.Id;
                    foreach (var item in processing.ProcessingLineItems)
                    {
                        item.UpdatedOn = DateTime.Now;
                    }
                    foreach (var item in processing.Notes)
                    {
                        item.UpdatedOn = DateTime.Now;
                    }
                    _context.Update(processing);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<List<Model.Processing>> GetEntities(long userId)
        {
            List<Model.Processing> processings = null;
            try
            {
                processings = await _context.Processings
                    .Include(x => x.Agent)
                    .Include(x => x.Order).ThenInclude(x => x.Currency)
                    .Include(x => x.ProcessingLineItems)
                    .Include(x => x.Status)
                    .Where(x => x.CreatedById == userId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return processings;
        }
        public async Task<Model.Processing> Get(long Id)
        {
            Model.Processing result = null;
            try
            {
                result = await _context.Processings.FindAsync(Convert.ToInt64(Id));
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
                _context.Processings.Remove(await _context.Processings.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Model.Processing>  GetLast()
        {
            List<Model.Processing> Entities = null;
            Model.Processing result = null;
            try
            {
                Entities = await _context.Processings.ToListAsync();
                result = Entities.OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
