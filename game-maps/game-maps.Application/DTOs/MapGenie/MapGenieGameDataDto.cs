using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieData
    {
        public string? name { get; set; }
        public string? slug { get; set; }
        public string? description { get; set; }
        public ICollection<MapGenieLocation> locations { get; set; }
        public MapGenieMapDto map { get; set; }
        public ICollection<MapGenieGroup> groups { get; set; }
        public IDictionary<int, MapGenieCategory> categories { get; set; }
        public MapGenieMapConfig mapConfig { get; set; }
    }
}
