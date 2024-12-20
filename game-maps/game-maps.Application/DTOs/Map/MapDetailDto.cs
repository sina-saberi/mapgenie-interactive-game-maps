namespace game_maps.Application.DTOs.Map;

public class MapDetailDto
{
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public string Slug { get; set; } = "";
    public MapConfigDto Config { get; set; } = new();
}