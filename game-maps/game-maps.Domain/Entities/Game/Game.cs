using game_maps.Domain.Base;
using game_maps.Domain.Entities.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Domain.Entities.Game
{
    public class Game : Entity<int>
    {
        public string Name { get; set; } = "";
        public string Slug { get; set; } = "";
        public string? Description { get; set; }
        public ICollection<Map.Map> Maps { get; set; } = [];
    }
}
