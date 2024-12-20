using game_maps.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace game_maps.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssetController(IFileStorageService storageService, IMapGenieService mapGenieService) : ControllerBase
{
    [HttpGet("{gameSlug}/{mapSlug}/{tileName}/{z}/{x}/{y}.{extension}")]
    public async Task<IActionResult> Get(string gameSlug, string mapSlug,
        string tileName, int z, int x, int y,
        string extension)
    {
        return File(await mapGenieService.GetTileByPattern(gameSlug, mapSlug, tileName, z, x, y, extension),
            $"image/{extension}");
    }

    [HttpGet("storage/media/{fileName}.{extension}")]
    public async Task<IActionResult> Get(string fileName, string extension)
    {
        return File(await mapGenieService.GetMedia(fileName, extension), $"image/{extension}");
    }

    [HttpGet("images/{slug}/{name}.{extension}")]
    public async Task<IActionResult> GetIcon(string slug, string name, string extension)
    {
        var bytes = await mapGenieService.GetIcon(slug, name, extension);
        if (bytes is null) return NotFound();
        return File(bytes, $"image/{extension}");
    }
}