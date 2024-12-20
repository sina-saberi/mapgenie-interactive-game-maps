using AutoMapper;
using game_maps.Application.DTOs.Game;
using game_maps.Application.DTOs.Location;
using game_maps.Application.DTOs.Map;
using game_maps.Domain.Entities.Category;
using game_maps.Domain.Entities.Game;
using game_maps.Domain.Entities.Location;
using game_maps.Domain.Entities.Map;

namespace game_maps.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
            CreateMap<CreateGameDto, Game>();
            CreateMap<Game, CreateGameDto>();

            CreateMap<MapDto, Map>();
            CreateMap<Map, MapDto>();


            CreateMap<Map, MapConfigDto>()
                .ForMember(dest => dest.StartLat, opt => opt.MapFrom(src => src.MapConfig.StartLat))
                .ForMember(dest => dest.StartLng, opt => opt.MapFrom(src => src.MapConfig.StartLng))
                .ForMember(dest => dest.InitialZoom, opt => opt.MapFrom(src => src.MapConfig.InitialZoom));
            // .ForMember(dest => dest.TileSets, opt => opt.MapFrom(src => src.TileSets))
            CreateMap<TileSet, TileSetDto>();

            CreateMap<LocationCateogryDto, Category>();
            CreateMap<Category, LocationCateogryDto>();

            CreateMap<LocationSearchDto, Location>();
            CreateMap<Location, LocationSearchDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<Location, LocationDto>()
                .ForMember(dest => dest.Checked, opt => opt.MapFrom((src, dest, destMember) =>
                {
                    if (src.UserLocations is not null)
                    {
                        var userLocation = src.UserLocations.FirstOrDefault();
                        return userLocation?.Checked;
                    }

                    return null;
                }));

            CreateMap<Location, LocationDetailDto>()
                .ForMember(dest => dest.CategoryTitle, 
                    opt => opt.MapFrom(src => src.Category != null ? src.Category.Title : string.Empty));
            CreateMap<LocationDetailDto, Location>();
            CreateMap<Media, MediaDto>();
            CreateMap<MediaDto, Media>();

            CreateMap<Map, MapDetailDto>()
                .ForMember(dest => dest.Config, opt => opt.MapFrom(src => src.MapConfig));
            CreateMap<MapConfig, MapConfigDto>()
                .ForMember(dest => dest.TileSets, opt => opt.MapFrom(src => src.TileSets));
            CreateMap<TileSet, TileSetDto>();
        }
    }
}