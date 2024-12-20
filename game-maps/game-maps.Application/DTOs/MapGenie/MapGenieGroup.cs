using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieGroup
    {
        public int id { get; set; }
        public int? game_id { get; set; }
        public string title { get; set; }
        public int? order { get; set; }
        public string? color { get; set; }
        public bool? expandable { get; set; }
        public ICollection<MapGenieCategory> categories { get; set; } = [];
    }
}
