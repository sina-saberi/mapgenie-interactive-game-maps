using game_maps.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Domain.Entities.Category
{
    public class Category : Entity<int>
    {
        public int BaseId { get; set; }
        public int MapId { get; set; }
        public string Group { get; set; } = string.Empty;
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
        public ICollection<Location.Location> Locations { get; set; } = [];
        public Map.Map Map { get; set; } = default!;
    }
}