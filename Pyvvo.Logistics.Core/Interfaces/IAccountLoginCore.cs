
using System.Threading.Tasks;
using Pyvvo.Logistics.Model;


namespace Pyvvo.Logistics.Core
{
    public interface ICoreAccountLogin
    {
        Task<string> SignUp(AccountLogin accountLogin);
        Task<AccountLogin> SignIn(Model.AccountLogin account);

    }
}