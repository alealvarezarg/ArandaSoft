using ArandaSoft.Login.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Service
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync(string filter, string rolname);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int idUser);
    }
}
