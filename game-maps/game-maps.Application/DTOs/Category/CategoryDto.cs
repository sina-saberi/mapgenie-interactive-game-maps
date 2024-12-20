using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string? Info { get; set; }
        public string? Template { get; set; }
        public int? Order { get; set; }
        public bool HasHeatmap { get; set; }
        public bool FeaturesEnabled { get; set; }
        public string DisplayType { get; set; } = string.Empty;
        public bool IgnEnabled { get; set; }
        public bool IgnVisible { get; set; }
        public bool Visible { get; set; } = true;
        public string Description { get; set; } = string.Empty;
        public int LocationCount { get; set; }
        public int CheckedCount { get; set; }
    }
}
