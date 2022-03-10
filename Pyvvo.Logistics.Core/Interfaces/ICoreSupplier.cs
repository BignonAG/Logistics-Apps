using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreSupplier
    {
          Task<Boolean> CreateSupplier(Supplier supplier, long userId);
          Task<Boolean> UpdateSupplier(Supplier supplier);
          Task<Boolean> DeleteSupplier(long id);
          Task<List<Supplier>> GetSuppliers(long userId);
          Task<Supplier> GetSupplier(long id);

    }
}