using ArandaSoft.Login.API.Database;
using ArandaSoft.Login.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Service
{
    public class RolService : IRolService
    {
        private readonly DatabaseContext _context;

        public RolService(DatabaseContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Rol>> GetRolesAsync(string rolname)
        {
            if (!string.IsNullOrWhiteSpace(rolname))
            {
                return await _context.Roles.Where(x => x.Rolname.Contains(rolname)).ToListAsync();
            }

            return await _context.Roles.ToListAsync();
        }

        public async Task AddRolAsync(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRolAsync(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRolAsync(int idRol)
        {
            var deletedRol = _context.Roles.Find(idRol);
            _context.Roles.Remove(deletedRol);
            await _context.SaveChangesAsync();
        }
    }
}
