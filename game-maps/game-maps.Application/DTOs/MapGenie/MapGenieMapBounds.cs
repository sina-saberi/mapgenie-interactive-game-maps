
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieMapBounds
    {
        public MapGeniaMapBoundMinAndMax x { get; set; }
        public MapGeniaMapBoundMinAndMax y { get; set; }
    }

    public class MapGeniaMapBoundMinAndMax
    {
        public int max { get; set; }
        public int min { get; set; }
    }
}
