using game_maps.Application.DTOs.Location;
using game_maps.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace game_maps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationService locationService) : ControllerBase
    {
        [HttpGet("{slug}")]
        public async Task<IList<LocationCateogryDto>> GetAllLocations(string gameSlug, string slug)
        {
            var id = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return await locationService.GetAllLocations(gameSlug, slug, id);
        }

        [HttpGet("locationDetail/{id}")]
        public async Task<LocationDetailDto> GetLocationById(int id)
        {
            return await locationService.GetLocationDetailById(id);
        }

        [HttpPost("toggle")]
        [Authorize]
        public async Task<bool> ToggleCheckLocation(int id)
        {
            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is not null)
                return await locationService.ToggleLocation(id, userId);
            throw new Exception("no user id has ben provided");
        }

        [HttpGet("search")]
        public async Task<IList<LocationSearchDto>> SearchForLocations(string gameSlug, string slug, string search)
        {
            return await locationService.SearchInLocation(gameSlug, slug, search);
        }
    }
}