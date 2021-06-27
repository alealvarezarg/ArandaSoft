using ArandaSoft.Login.API.Model;
using ArandaSoft.Login.API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUsersAsync(string filter, string rolname)
        {
            var users = await _service.GetUsersAsync(filter, rolname);

            return Ok(users);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUserAsync(User user)
        {
            await _service.AddUserAsync(user);

            return Ok("User created");
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            await _service.UpdateUserAsync(user);

            return Ok("User updated");
        }

        [HttpGet("delete")]
        public async Task<IActionResult> DeleteUserAsync(int idUser)
        {
            await _service.DeleteUserAsync(idUser);

            return Ok("User deleted");
        }
    }
}
