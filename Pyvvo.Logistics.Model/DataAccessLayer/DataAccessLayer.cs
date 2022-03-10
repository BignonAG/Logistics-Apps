using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class DataAccessLayer<T> where T : class
    {
        private DatabaseContext _context;
        public DataAccessLayer(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> AddOrUpdate(T entity)
        {
            int result = 0;
            try
            {
                _context.Update(entity);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<int> AddOrUpdate(ICollection<T> entities)
        {
            int result = 0;
            try
            {
                _context.UpdateRange(entities);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<int> Delete(T entity)
        {
            int result = 0;
            try
            {
                _context.Remove(entity);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public virtual async Task<T> Get(object param)
        {
            T entity = null;
            try
            {
                entity = await _context.Set<T>().FindAsync(Convert.ToInt64(param));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public virtual async Task<List<T>> GetEntities()
        {
            List<T> entities = null;
            try
            {

                entities = await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }

        public virtual async Task<T> GetEntityPredicate(Expression<Func<T, bool>> predicate)
        {
            T entity = null;
            try
            {
                entity = await _context.Set<T>().FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public virtual async Task<List<T>> GetEntities(Expression<Func<T, bool>> predicate)
        {
            List<T> entities = null;
            try
            {
                entities = await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }

        public  virtual void DetachLocal(T entity)
        {
            try
            {
                var local = _context.Set<T>()
                .Local
                .FirstOrDefault(x => x == entity);

                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }       
        }


    }
}
