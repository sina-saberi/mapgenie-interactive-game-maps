using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieMapConfig
    {
        public ICollection<MapGenieTileSets> tile_sets { get; set; }
        public int initial_zoom { get; set; }
        public decimal start_lat { get; set; }
        public decimal start_lng { get; set; }
        public string? overlay { get; set; }
        public bool overzoom { get; set; }
    }
}
