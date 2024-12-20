using game_maps.Domain.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace game_maps.Infrastructure.EntityConfiguration
{
    internal class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(600);
            builder.Property(m => m.Description).HasMaxLength(1000);
            builder.Property(m => m.Slug).HasMaxLength(500);
            
            builder.HasIndex(m => m.Slug).IsUnique();
            
            builder.HasMany(x => x.Maps)
                .WithOne(x=>x.Game)
                .HasForeignKey(x => x.GameId);
        }
    }
}
