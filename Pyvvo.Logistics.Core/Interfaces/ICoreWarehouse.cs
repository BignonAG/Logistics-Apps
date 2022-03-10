using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pyvvo.Logistics.Model;


namespace Pyvvo.Logistics.Core
{
    public interface ICoreWarehouse
    {
        Task<Boolean> Create(Warehouse warehouse, long userId, long statusId);
        Task<Boolean> Update(Warehouse warehouse);
        Task<Boolean> Delete(long id);
        Task<List<Warehouse>> GetList();
        Task<List<Warehouse>> GetList(long userId);
        Task<Warehouse> Get(long id);
    }
}