using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.Location
{
    public class LocationDto
    {
        public virtual int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool? Checked { get; set; }
    }
}
