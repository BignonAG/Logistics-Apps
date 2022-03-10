using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class UserCore : ICoreUser
    {
        private readonly DatabaseContext _context;

        public UserCore(DatabaseContext context)
        {

            _context = context;
        }

        public async Task<Boolean> CreateUser(User user, long userId, long roleId)
        {
            Boolean result = false;
            try
            {
                if (user != null)
                {

                    if (user.Status != null)
                        user.StatusId = user.Status.Id; ;
                    user.IsActive = true;
                    user.CreateDon = user.UpdateDon = DateTime.Now;
                    user.CreatedBy = await GetUser(userId);
                    // user.Role = roleId;

                    if (user.Contact != null)
                    {
                        user.Contact.StatusId = user.StatusId;
                        user.Contact.CreateDon = user.Contact.UpdateDon = DateTime.Now;
                    }
                    _context.Users.Update(user);
                    result = await _context.SaveChangesAsync() > 0;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }
        public async Task<User> GetLite(object userId)
        {
            User user = null;
            try
            {
                user = await _context.Users
                  .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(userId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public async Task<Boolean> UpdateUser(User user)
        {
            Boolean result = false;
            try
            {
                if (user != null)
                {
                    bool userExist = await _context.Customers.FindAsync(Convert.ToInt64(user.Id)) != null;
                    if (userExist)
                    {
                        // user.IsActive = dbuser.IsActive;
                        // user.CreateDon = dbuser.CreateDon;
                        user.UpdateDon = DateTime.Now;
                        if (user.Contact != null)
                        {
                            user.Contact.UpdateDon = DateTime.Now;
                            // user.Contact.IsActive = dbuser.Contact.IsActive;
                            // user.Contact.CreateDon = dbuser.Contact.CreateDon;
                        }
                        _context.Users.Update(user);
                        result = await _context.SaveChangesAsync() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }
        public async Task<Boolean> DeleteUser(long id)
        {
            Boolean result = false;
            try
            {
                _context.Users.Remove(await _context.Users.FindAsync(Convert.ToInt64(id)));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<List<Model.User>> GetUsers(long createdById)
        {
            List<User> users = null;
            try
            {

                users = await _context.Users
                    .Include(x => x.Contact)
                    .Where(x => x.CreatedBy.Id == createdById)
                    .OrderByDescending(x => x.CreateDon)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }
        public async Task<Model.User> GetUser(long id)
        {
            User user = null;
            try
            {
                user = await _context.Users
                  .Include(c => c.Contact)
                  .Include(c => c.Status)
                  .Include(c => c.Company)
                  .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
    }
            return user;
        }

    }
}
