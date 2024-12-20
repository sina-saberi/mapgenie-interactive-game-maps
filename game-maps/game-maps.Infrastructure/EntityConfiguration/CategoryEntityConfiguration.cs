using game_maps.Domain.Entities.Category;
using game_maps.Domain.Entities.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Infrastructure.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MapId).IsRequired();
            builder.Property(x => x.Group).HasMaxLength(1000).IsRequired().HasDefaultValue("other");
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Icon).HasMaxLength(500);
            builder.Property(x => x.Info).HasMaxLength(900);
            builder.Property(x => x.Template).HasMaxLength(3000);
            builder.Property(x => x.Order).HasDefaultValue(1);
            builder.Property(x => x.HasHeatmap).HasDefaultValue(false);
            builder.Property(x => x.FeaturesEnabled).HasDefaultValue(false);
            builder.Property(x => x.DisplayType).IsRequired().HasDefaultValue("marker");
            builder.Property(x => x.IgnEnabled).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.IgnVisible).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.Visible).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.Description).HasMaxLength(5000);
            builder.HasMany(x => x.Locations).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}