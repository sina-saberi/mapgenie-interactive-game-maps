using game_maps.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IList<GroupedCategoryDto>> GetGroupedCategories(string gameSlug, string slug, string? userId);
    }
}