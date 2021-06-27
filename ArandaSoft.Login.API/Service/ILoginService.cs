using ArandaSoft.Login.API.Model;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Service
{
    public interface ILoginService
    {
        Task<User> LoginAsync(string username, string password);
    }
}
