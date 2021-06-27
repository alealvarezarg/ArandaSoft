using ArandaSoft.Login.API.Database;
using ArandaSoft.Login.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Service
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<User>> GetUsersAsync(string filter, string rolname)
        {
            var query = _context.Users.Include("Rol");

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(x => x.Username.Contains(filter) || x.Name.Contains(filter) || x.Lastname.Contains(filter));
            }

            if (!string.IsNullOrWhiteSpace(rolname))
            {
                query = query.Where(x => x.Rol.Rolname.Contains(rolname));
            }

            return await query.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            var rol = await _context.Roles.FindAsync(user.Rol.Id);
            user.Rol = rol;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int idUser)
        {
            var deletedUser = _context.Users.Find(idUser);
            _context.Users.Remove(deletedUser);
            await _context.SaveChangesAsync();
        }
    }
}
