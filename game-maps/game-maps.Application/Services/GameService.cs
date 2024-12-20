using AutoMapper;
using game_maps.Application.DTOs.Game;
using game_maps.Application.Interfaces;
using game_maps.Domain.Base;
using game_maps.Domain.Entities.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace game_maps.Application.Services
{
    public class GameService(IMapper mapper, IRepository<Game, int> gameRepository) : IGameService
    {
        public async Task<IEnumerable<GameDto>> GetAllGames()
        {
            return mapper.Map<List<GameDto>>(await gameRepository.ToListAsync());
        }

        public async Task<GameDto> CreateGame(CreateGameDto dto)
        {
            var game = await gameRepository.AddAsync(mapper.Map<Game>(dto));
            return mapper.Map<GameDto>(game);
        }
    }
}