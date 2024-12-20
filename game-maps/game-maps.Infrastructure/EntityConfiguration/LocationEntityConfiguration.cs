using game_maps.Domain.Base;
using game_maps.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Infrastructure.EntityConfiguration
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.CategoryId).IsRequired();
            builder.Property(m => m.Title).IsRequired().HasMaxLength(1000);
            builder.Property(m => m.Description).HasMaxLength(8000);
            builder.Property(m => m.Latitude).IsRequired();
            builder.Property(m => m.Longitude).IsRequired();

            builder.HasMany(e => e.UserLocations)
                .WithOne()
                .HasForeignKey(ul => ul.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Medias).WithOne().HasForeignKey(x => x.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
