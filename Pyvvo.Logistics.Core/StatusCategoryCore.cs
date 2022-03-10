using System;
using System.Threading.Tasks;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;

namespace Pyvvo.Logistics.Core
{
    public class StatusCategoryCore:ICoreStatusCategory
    {
        private readonly DatabaseContext _context;

        public StatusCategoryCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Boolean> AddOrdUpdate(StatusCategory statusCategory) //A supprimer
        {
            Boolean result = false;
            try
            {
                statusCategory.CreateDon = statusCategory.UpdateDon = DateTime.Now;
                _context.Update(statusCategory);
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<StatusCategory> GetStatusCategory(long id)
        {
           StatusCategory result = null;
            try
            {
                result = await _context.StatusCategories.FindAsync(Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Boolean> Create(StatusCategory statusCategory)
        {
            Boolean result = false;
            try
            {
                statusCategory.CreateDon =statusCategory.UpdateDon = DateTime.Now;
                _context.Update(statusCategory);
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }
        public async Task<Boolean> Update(StatusCategory statusCategory)
        {
            Boolean result = false;
            try
            {
                statusCategory.UpdateDon = DateTime.Now;
                _context.Update(statusCategory);
                result = await _context.SaveChangesAsync() > 0;
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
                _context.StatusCategories.Remove(await _context.StatusCategories.FindAsync(Convert.ToInt64(id)));
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
