using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieTileSets
    {
        public int id { get; set; }
        public int map_id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string extension { get; set; }
        public string pattern { get; set; }
        public int min_zoom { get; set; }
        public int max_zoom { get; set; }
        public int order { get; set; }
        public IDictionary<int, MapGenieMapBounds> bounds { get; set; }
    }
}
