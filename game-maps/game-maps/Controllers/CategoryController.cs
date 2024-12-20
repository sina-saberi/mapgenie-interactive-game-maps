using game_maps.Application.DTOs.Category;
using game_maps.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace game_maps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService, ILocationService locationService) : ControllerBase
    {
        [HttpGet("{slug}")]
        public async Task<SideBarDto> Get(string gameSlug, string slug)
        {
            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return new SideBarDto
            {
                LocationCount = await locationService.GetLocationCount(gameSlug, slug),
                CheckedCount = userId is not null ? await locationService.GetCheckedCount(gameSlug, slug, userId) : 0,
                Groups = await categoryService.GetGroupedCategories(gameSlug, slug, userId)
            };
        }
    }
}