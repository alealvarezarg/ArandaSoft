using ArandaSoft.Login.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Service
{
    public interface IRolService
    {
        Task<List<Rol>> GetRolesAsync(string rolname);
        Task AddRolAsync(Rol rol);
        Task UpdateRolAsync(Rol rol);
        Task DeleteRolAsync(int idRol);
    }
}
