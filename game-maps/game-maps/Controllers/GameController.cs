using System.Security.Claims;
using game_maps.Application.DTOs.Game;
using game_maps.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace game_maps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(IGameService game) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GameDto>> Get()
        {
            return await game.GetAllGames();
        }

        [HttpPost]
        [Authorize]
        public async Task<GameDto> Post(CreateGameDto dto)
        {
            return await game.CreateGame(dto);
        }
    }
}