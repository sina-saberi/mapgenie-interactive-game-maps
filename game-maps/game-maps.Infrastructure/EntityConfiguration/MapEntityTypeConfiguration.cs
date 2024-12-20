using game_maps.Domain.Entities.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;


namespace game_maps.Infrastructure.EntityConfiguration
{
    internal class MapEntityTypeConfiguration : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.GameId).IsRequired();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(1000);
            builder.Property(m => m.Description).HasMaxLength(1000);
            builder.Property(m => m.Slug).HasMaxLength(400);
            builder.HasMany(x => x.Categories).WithOne(x=>x.Map).HasForeignKey(x => x.MapId);

            var jsonConverter = new ValueConverter<MapConfig, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<MapConfig>(v) ?? new MapConfig());

            builder.Property(x => x.MapConfig).HasColumnType("jsonb").HasConversion(jsonConverter);
        }
    }
}