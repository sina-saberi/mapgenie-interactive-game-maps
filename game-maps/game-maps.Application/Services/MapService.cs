using AutoMapper;
using game_maps.Application.DTOs.Map;
using game_maps.Application.Interfaces;
using game_maps.Domain.Base;
using game_maps.Domain.Entities.Game;
using game_maps.Domain.Entities.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.Services
{
    public class MapService(IRepository<Map, int> mapRepository, IRepository<Game, int> gameRepository, IMapper mapper)
        : IMapService
    {
        public async Task<IList<MapDto>> GetAllAsync()
        {
            var result = await mapRepository.ToListAsync();
            return mapper.Map<List<MapDto>>(result);
        }

        public async Task<IList<MapDto>> GetAllAsync(string slug)
        {
            var game = await gameRepository.AsQueryable()
                .Include(x => x.Maps)
                .FirstOrDefaultAsync(x => x.Slug == slug);

            return mapper.Map<List<MapDto>>(game?.Maps);
        }

        public async Task<MapDetailDto> GetMapDetail(string gameSlug, string slug)
        {
            var game = await gameRepository.AsQueryable()
                .Include(x => x.Maps.Where(c => c.Slug.Equals(slug)))
                .FirstOrDefaultAsync(x => x.Slug.Equals(gameSlug));
            return mapper.Map<MapDetailDto>(game?.Maps.FirstOrDefault());
        }
    }
}