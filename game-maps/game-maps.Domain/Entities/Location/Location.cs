using game_maps.Domain.Base;
using game_maps.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Domain.Entities.Location
{
    public class Location : Entity<int>
    {
        public int BaseId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Category.Category Category { get; set; } = default!;
        public ICollection<Media> Medias { get; set; } = [];
        public virtual ICollection<UserLocation> UserLocations { get; set; } = [];
    }
}