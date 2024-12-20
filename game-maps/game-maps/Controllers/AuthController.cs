using game_maps.Application.DTOs.Auth;
using game_maps.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace game_maps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService user) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<LoginResponseDto> Login([FromBody] LoginDto model)
        {
            return await user.Login(model);
        }

        [HttpPost("register")]
        public async Task Register([FromBody] RegisterDto model)
        {
            await user.Register(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<bool> HaveAccess(string action)
        {
            return true;
        }
    }
}
