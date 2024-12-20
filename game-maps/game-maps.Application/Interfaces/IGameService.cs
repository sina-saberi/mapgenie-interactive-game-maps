using game_maps.Application.DTOs.Game;

namespace game_maps.Application.Interfaces
{
    public interface IGameService
    {
        public Task<IEnumerable<GameDto>> GetAllGames();
        public Task<GameDto> CreateGame(CreateGameDto dto);
    }
}