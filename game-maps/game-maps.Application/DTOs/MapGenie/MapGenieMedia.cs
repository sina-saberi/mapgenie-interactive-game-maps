using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class MapGenieMedia
    {
        public int id { get; set; }
        public string title { get; set; }
        public string file_name { get; set; }
        public string attribution { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string mime_type { get; set; }
        public string meta { get; set; }
        public int order { get; set; }
    }
}
