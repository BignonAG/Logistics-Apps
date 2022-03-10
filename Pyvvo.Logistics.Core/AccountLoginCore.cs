using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pyvvo.Logistics.Model;

namespace Pyvvo.Logistics.Core
{
    public class AccountLoginCore : ICoreAccountLogin
    {
        private readonly DatabaseContext _context;

        public AccountLoginCore(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<string> SignUp(AccountLogin accountLogin)
        {
            try
            {
                accountLogin.CreatedOn = DateTime.Now;
                accountLogin.UpdatedOn = DateTime.Now;
                accountLogin.User = new User();
                accountLogin.User.IsActive = true;
                accountLogin.User.CreateDon = DateTime.Now;
                var Role = await _context.Roles.FindAsync(Convert.ToInt64(1));
                accountLogin.User.Role = Role;
                _context.AccountLogins.Update(accountLogin);
                var result = await _context.SaveChangesAsync();
                string token = null;
                if (result > 0)
                {
                    token = GenerateToken(accountLogin.User.Id);
                }
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<AccountLogin> SignIn(Model.AccountLogin account)
        {
            var dbAccount = await _context.AccountLogins
                    .Include(x => x.User).ThenInclude(x => x.Company)
                    .FirstOrDefaultAsync(x => x.Email == account.Email);
            if (dbAccount != null)
            {
                if (dbAccount.Password == account.Password)
                {
                    dbAccount.Token = GenerateToken(dbAccount.User.Id);
                    if (dbAccount.Token != null)
                        return dbAccount;
                }
            }
            return null;
        }
        public string GenerateToken(long userId)
        {
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim("userId", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                             new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Properties.Resources.JWT_Secret)),
                             SecurityAlgorithms.HmacSha256Signature
                         )
            };

            var tokenHandeler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandeler.CreateToken(tokenDescription);
            var token = tokenHandeler.WriteToken(securityToken);
            return token;
        }

    }
}
