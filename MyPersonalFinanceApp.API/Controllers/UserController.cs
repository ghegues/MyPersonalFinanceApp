using Microsoft.AspNetCore.Mvc;
using MyPersonalFinanceApp.Application.DTOs;
using MyPersonalFinanceApp.Application.Interfaces;

namespace MyPersonalFinanceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            var response = await _userService.RegisterUserAsync(userDTO);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        // Implemente outros métodos da UserController conforme necessário
    }
}
