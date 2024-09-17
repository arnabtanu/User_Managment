using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Services;
using UserManagement.Services.Interface;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserservice _userservice;
        public UserController(IUserservice userservice) 
        {
            _userservice = userservice;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Users user)
        {
            await _userservice.CreateUserAsync(user);
            return Ok(user);
        }
    }
}
