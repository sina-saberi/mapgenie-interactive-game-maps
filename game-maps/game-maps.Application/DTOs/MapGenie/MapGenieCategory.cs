using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieCategory
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string? info { get; set; }
        public string? template { get; set; }
        public int order { get; set; }
        public bool has_heatmap { get; set; }
        public bool features_enabled { get; set; }
        public string display_type { get; set; }
        public bool ign_enabled { get; set; }
        public bool ign_visible { get; set; }
        public bool visible { get; set; }
        public string? description { get; set; }
        public bool premium { get; set; }
    }
}
