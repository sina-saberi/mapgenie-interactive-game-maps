namespace game_maps.Application.DTOs.Game;

public class CreateGameDto
{
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public string? Description { get; set; }
}