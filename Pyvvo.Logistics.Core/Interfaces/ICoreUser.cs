using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pyvvo.Logistics.Model;


namespace Pyvvo.Logistics.Core
{
    public interface ICoreUser
    {
        Task<Boolean> CreateUser(User user, long userId, long roleId);
        Task<User> GetLite(object userId);
        Task<Boolean> UpdateUser(User user);
        Task<Boolean> DeleteUser(long id);
        Task<List<Model.User>> GetUsers(long createdById);
        Task<Model.User> GetUser(long id);
    }
}