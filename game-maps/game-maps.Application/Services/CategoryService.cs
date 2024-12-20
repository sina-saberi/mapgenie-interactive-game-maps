using game_maps.Application.DTOs.Category;
using game_maps.Application.Interfaces;
using game_maps.Domain.Base;
using Microsoft.EntityFrameworkCore;
using game_maps.Domain.Entities.Game;

namespace game_maps.Application.Services
{
    public class CategoryService(IRepository<Game, int> gameRepository) : ICategoryService
    {
        public async Task<IList<GroupedCategoryDto>> GetGroupedCategories(string gameSlug, string slug, string? userId)
        {
            var game = await
                gameRepository.AsQueryable()
                    .Include(x => x.Maps.Where(c => c.Slug.Equals(slug)))
                    .ThenInclude(x => x.Categories)
                    .ThenInclude(x => x.Locations)
                    .ThenInclude(x => x.UserLocations.Where(c => c.UserId == userId))
                    .FirstOrDefaultAsync(x => x.Slug.Equals(gameSlug));

            var map = game?.Maps.FirstOrDefault();
            var groupedCategory = new List<GroupedCategoryDto>();
            if (map?.Categories == null) return groupedCategory;
            {
                var groupedCategories = map.Categories.GroupBy(c => c.Group);
                groupedCategory.AddRange(groupedCategories.Select(group => new GroupedCategoryDto
                {
                    Title = group.Key,
                    categories = group.Select(category => new CategoryDto
                        {
                            Id = category.Id,
                            Title = category.Title,
                            Icon = category.Icon,
                            Info = category.Info,
                            Template = category.Template,
                            Order = category.Order,
                            HasHeatmap = category.HasHeatmap,
                            FeaturesEnabled = category.FeaturesEnabled,
                            DisplayType = category.DisplayType,
                            IgnEnabled = category.IgnEnabled,
                            IgnVisible = category.IgnVisible,
                            Visible = category.Visible,
                            Description = category.Description,
                            LocationCount = category.Locations.Count,
                            CheckedCount = category.Locations.Count(x => x.UserLocations.Any(c => c.Checked))
                        })
                        .ToList()
                }));
            }

            return groupedCategory;
        }
    }
}