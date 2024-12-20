using game_maps.Application.DTOs.Auth;
using game_maps.Application.Interfaces;
using game_maps.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;

namespace game_maps.Application.Services
{
    public class UserService(ITokenService tokenService, UserManager<User> userManager) : IUserService
    {
        public async Task<LoginResponseDto> Login(LoginDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null) throw new Exception("could not found user");

            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = tokenService.GenerateAccessToken(claims);
            var refreshToken = tokenService.GenerateRefreshToken(user);

            return new LoginResponseDto()
            {
                AccessToken = token,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(240),
            };
        }

        public async Task Register(RegisterDto model)
        {
            var user = new User { UserName = model.Username, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);
            switch (result.Succeeded)
            {
                case true:
                    await userManager.AddToRoleAsync(user, "User");
                    break;
                case false:
                    throw new Exception("could not crete this user");
            }
        }
    }
}