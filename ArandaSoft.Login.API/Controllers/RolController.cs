using ArandaSoft.Login.API.Model;
using ArandaSoft.Login.API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _service;
        public RolController(IRolService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetRolesAsync(string rolname)
        {
            var users = await _service.GetRolesAsync(rolname);

            return Ok(users);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRolAsync(Rol rol)
        {
            await _service.AddRolAsync(rol);

            return Ok("Rol created");
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRolAsync(Rol rol)
        {
            await _service.UpdateRolAsync(rol);

            return Ok("Rol updated");
        }

        [HttpGet("delete")]
        public async Task<IActionResult> DeleteRolAsync(int idRol)
        {
            await _service.DeleteRolAsync(idRol);

            return Ok("Rol deleted");
        }
    }
}
