using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieSetting
    {
        public string GameName { get; set; }
        public string GameSlug { get; set; }
        public string? GameBaseURL { get; set; }
    }
}
