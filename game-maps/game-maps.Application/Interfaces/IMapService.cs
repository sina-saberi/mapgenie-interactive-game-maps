using game_maps.Application.DTOs.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Application.Interfaces
{
    public interface IMapService
    {
        public Task<IList<MapDto>> GetAllAsync();
        public Task<IList<MapDto>> GetAllAsync(string slug);
        public Task<MapDetailDto> GetMapDetail(string gameSlug, string slug);
    }
}