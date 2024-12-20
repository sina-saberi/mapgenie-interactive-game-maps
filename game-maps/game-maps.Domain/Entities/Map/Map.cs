using game_maps.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Domain.Entities.Map
{
    public class Map : Entity<int>
    {
        public int GameId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string Slug { get; set; } = "";
        public MapConfig MapConfig { get; set; } = new();
        public ICollection<Category.Category> Categories { get; set; } = [];
        public Game.Game Game { get; set; } = default!;
    }
}
