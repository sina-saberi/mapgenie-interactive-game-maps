using game_maps.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Domain.Entities.Location
{
    public class Media : Entity<int>
    {
        public int LocationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string MimeType { get; set; } = string.Empty;
    }
}
