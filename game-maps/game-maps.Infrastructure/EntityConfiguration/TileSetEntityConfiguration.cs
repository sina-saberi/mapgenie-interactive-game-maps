// using game_maps.Domain.Entities.Game;
// using game_maps.Domain.Entities.Map;
// using game_maps.Domain.Entities.TileSet;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
//
// namespace game_maps.Infrastructure.EntityConfiguration
// {
//     internal class TileSetEntityConfiguration : IEntityTypeConfiguration<TileSet>
//     {
//         public void Configure(EntityTypeBuilder<TileSet> builder)
//         {
//             builder.HasKey(ts => ts.Id);
//
//             builder.Property(ts => ts.MapId).IsRequired();
//             builder.Property(m => m.Name).IsRequired().HasMaxLength(300);
//             builder.Property(ts => ts.Extension).IsRequired();
//             builder.Property(ts => ts.Pattern).IsRequired();
//             builder.Property(ts => ts.MinZoom).IsRequired();
//             builder.Property(ts => ts.MaxZoom).IsRequired();
//         }
//     }
// }
