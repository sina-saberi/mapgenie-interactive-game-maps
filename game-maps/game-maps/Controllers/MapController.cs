using game_maps.Application.DTOs.Map;
using game_maps.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace game_maps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController(IMapService mapService) : ControllerBase
    {
        private readonly IMapService _mapService = mapService;

        [HttpGet]
        public async Task<IList<MapDto>> Get()
        {
            return await _mapService.GetAllAsync();
        }

        [HttpGet("{slug}")]
        public async Task<IList<MapDto>> Get(string slug)
        {
            return await _mapService.GetAllAsync(slug);
        }

        [HttpGet("detail/{slug}")]
        public async Task<MapDetailDto> GetMapConfig(string gameSlug, string slug)
        {
            return await _mapService.GetMapDetail(gameSlug, slug);
        }
    }
}