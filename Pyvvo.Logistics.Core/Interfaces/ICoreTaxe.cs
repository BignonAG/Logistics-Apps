using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreTaxe
    {
        Task<Taxe> Get(long Id);
        Task<List<Taxe>> GetEntities();

    }
}