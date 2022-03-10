using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class StatusCore : ICoreStatus
    {
        private readonly DatabaseContext _context;

        public StatusCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> CreateStatus(Status status, long statusCategoryId)
        {
            Boolean result = false;
            try
            {
                if (status != null)
                {
                    status.CreateDon = status.UpdateDon = DateTime.Now;
                    status.StatusCategoryId = statusCategoryId;
                }
                _context.Update(status);
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }

        public async Task<Status> GetStatus(long id)
        {
            Status entity = null;
            try
            {
                entity = await _context.Status
                    .Include(x => x.StatusCategory)
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public async Task<List<Status>> GetAllStatus(long categoryId)
        {
            List<Status> entities = null;
            try
            {
                entities = await _context.Status.Where(x => x.StatusCategory.Id == categoryId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }
    }
}
