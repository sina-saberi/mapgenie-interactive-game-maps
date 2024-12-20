using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Category
{
    public class GroupedCategoryDto
    {
        public string Title { get; set; } = string.Empty;
        public IList<CategoryDto> categories { get; set; } = [];
    }
}
