using game_maps.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResponseDto> Login(LoginDto model);
        public Task Register(RegisterDto model);
    }
}
