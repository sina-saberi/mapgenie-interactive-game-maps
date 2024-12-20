using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieMarketDto
    {
        public decimal width { get; set; }
        public decimal height { get; set; }
        public decimal x { get; set; }
        public decimal y { get; set; }
        public decimal pixelRatio { get; set; }
    }
}
