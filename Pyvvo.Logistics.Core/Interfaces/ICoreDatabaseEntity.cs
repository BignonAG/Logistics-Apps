using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreDatabaseEntity 
    {
        Task<Boolean> Create(DatabaseEntity databaseEntity);
        Task<Boolean> Update(DatabaseEntity databaseEntity);
        Task<Boolean> Delete(long id);
        Task<DatabaseEntity> Get(long id);

    }
}