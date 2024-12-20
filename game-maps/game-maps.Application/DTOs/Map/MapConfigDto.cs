using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Map
{
    public class MapConfigDto
    {
        public int InitialZoom { get; set; }
        public decimal StartLat { get; set; }
        public decimal StartLng { get; set; }
        public ICollection<TileSetDto> TileSets { get; set; } = [];
    }
}
