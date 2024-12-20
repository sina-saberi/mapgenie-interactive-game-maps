using game_maps.Application.DTOs.MapGenie;
using game_maps.Domain.Entities.Game;
using Microsoft.AspNetCore.Http;

namespace game_maps.Application.Interfaces
{
    public interface IMapGenieService
    {
        public Task ToggleMapToGame(string slug, IList<IFormFile> files, string? userId);

        public Task<byte[]> GetTileByPattern(string gameSlug, string mapSlug, string tileName, int z, int x, int y,
            string extension);

        public Task<byte[]> GetMedia(string fileName, string extension);

        public Task<byte[]?> GetIcon(string slug, string name, string extension);
    }
}