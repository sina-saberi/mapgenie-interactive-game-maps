using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Map
{
    public class TileSetDto
    {
        public string Name { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public string Pattern { get; set; } = string.Empty;
        public int MinZoom { get; set; }
        public int MaxZoom { get; set; }
    }
}
