using System.Threading.Tasks;
using Pyvvo.Logistics.Model;


namespace Pyvvo.Logistics.Core
{
    public interface ICoreRole
    {
        Task<Role> GetRole(long id);

    }
}