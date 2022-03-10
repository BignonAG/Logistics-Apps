using System;
using System.Threading.Tasks;
using Pyvvo.Logistics.Model;



namespace Pyvvo.Logistics.Core
{
    public class DatabaseEntityCore:ICoreDatabaseEntity
    {
        private readonly DatabaseContext _context;

        public DatabaseEntityCore(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Boolean> Create(DatabaseEntity databaseEntity)
        {
            bool result = false;
            try
            {
                databaseEntity.CreatedOn = databaseEntity.UpdatedOn = DateTime.Now;
                _context.DatabaseEntities.Update(databaseEntity);
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<Boolean> Update(DatabaseEntity databaseEntity)
        {
            bool result = false;
            try
            {
                databaseEntity.UpdatedOn = DateTime.Now;
                _context.DatabaseEntities.Update(databaseEntity);
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
                    _context.DatabaseEntities.Remove(await _context.DatabaseEntities.FindAsync(Convert.ToInt64(id)));
                    result = await _context.SaveChangesAsync() >0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result ;
        }

        public async Task<DatabaseEntity> Get(long id)
        {
            DatabaseEntity result = null;
            try
            {
                result = await _context.DatabaseEntities.FindAsync(Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        // public async Task<List<DatabaseEntity>> GetDatabaseEntitiesByName(string name)
        // {
        //     var result = await dataAccessLayer.GetEntities(x => x.Name == name);
        //     return result;
        // }
    }
}
