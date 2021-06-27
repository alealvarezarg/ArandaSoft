using ArandaSoft.Login.API.Database;
using ArandaSoft.Login.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Service
{
    public class LoginService : ILoginService
    {
        private readonly DatabaseContext _context;

        public LoginService(DatabaseContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var loginUser = await _context.Users.Include("Rol")
                .Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                .FirstOrDefaultAsync();

            return loginUser;
        }
    }
}
