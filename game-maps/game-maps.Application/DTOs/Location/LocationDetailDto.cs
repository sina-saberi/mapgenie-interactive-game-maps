using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Location
{
    public class LocationDetailDto
    {
        public required string CategoryTitle { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IList<MediaDto>? Medias { get; set; }
    }
}