using System.Security.Claims;
using game_maps.Application.DTOs.MapGenie;
using game_maps.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace game_maps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapGenieController(IMapGenieService mapGenieService) : ControllerBase
    {
        [HttpPost("{slug}")]
        [Authorize]
        public async Task Post(string slug, [FromForm] IList<IFormFile> files)
        {
            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            await mapGenieService.ToggleMapToGame(slug, files, userId);
        }
    }
}