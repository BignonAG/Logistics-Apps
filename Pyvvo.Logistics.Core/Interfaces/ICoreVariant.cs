using System.Threading.Tasks;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreVariant
    {
          Task<Model.Variant> Get(long id);
          Task<Boolean> Update(Model.Variant variant);
          Task<Boolean> Delete(long id);

    }
}