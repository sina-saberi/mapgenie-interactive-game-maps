namespace game_maps.Domain.Entities.Map
{
    public class TileSet
    {
        public string Name { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public string Pattern { get; set; } = string.Empty;
        public int MinZoom { get; set; }
        public int MaxZoom { get; set; }
    }
}