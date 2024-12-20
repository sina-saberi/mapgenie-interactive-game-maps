using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class ScrapMarketDto
    {
        public required string Slug { get; set; }
        public required string MarkerImgURL { get; set; }
        public required string MarkerJSONURL { get; set; }
    }
}
