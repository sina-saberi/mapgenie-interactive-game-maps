using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Domain.Entities.Map
{
    public class MapConfig
    {
        public int InitialZoom { get; set; }
        public decimal StartLat { get; set; }
        public decimal StartLng { get; set; }
        public ICollection<TileSet> TileSets { get; set; } = [];
    }
}