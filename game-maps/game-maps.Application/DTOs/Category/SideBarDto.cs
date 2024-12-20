using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Category
{
    public class SideBarDto
    {
        public int LocationCount { get; set; }
        public int CheckedCount { get; set; }
        public IList<GroupedCategoryDto> Groups { get; set; } = [];
    }
}
