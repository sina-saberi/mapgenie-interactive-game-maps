using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Map
{
    public class MapDto
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string Slug { get; set; } = "";
    }
}
