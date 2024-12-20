using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Location
{
    public class LocationCateogryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string? Info { get; set; }
        public string? Template { get; set; }
        public string DisplayType { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public IList<LocationDto> Locations { get; set; } = new List<LocationDto>();
    }
}
