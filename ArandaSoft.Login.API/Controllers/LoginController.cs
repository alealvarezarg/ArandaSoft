using ArandaSoft.Login.API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ArandaSoft.Login.API.Model;

namespace ArandaSoft.Login.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginModel login)
        {
            var user = await _service.LoginAsync(login.Username, login.Password);

            if (user is null)
            {
                return NotFound("Invalid login");
            }

            return Ok(user);
        }
    }
}
