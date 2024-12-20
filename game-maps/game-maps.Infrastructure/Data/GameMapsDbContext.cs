using game_maps.Domain.Entities.Category;
using game_maps.Domain.Entities.Game;
using game_maps.Domain.Entities.Location;
using game_maps.Domain.Entities.Map;
using game_maps.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace game_maps.Infrastructure.Data
{
    public class GameMapsDbContext(DbContextOptions<GameMapsDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Game> Games { get; init; }
        public DbSet<Map> Maps { get; init; }
        public DbSet<UserLocation> UserLocations { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<Location> Locations { get; init; }
        public DbSet<Media> Medias { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameMapsDbContext).Assembly);

            var roles = new List<IdentityRole>
            {
                new() { Id = "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", Name = "Admin", NormalizedName = "ADMIN" },
                new() { Id = "cd6da49a-8c12-4938-9854-5c17fdf4a24d",Name = "User", NormalizedName = "USER" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true,
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");

            modelBuilder.Entity<User>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roles.First(r => r.Name == "Admin").Id,
                UserId = adminUser.Id
            });

            var roleClaims = new List<IdentityRoleClaim<string>>
            {
                new()
                {
                    Id = 1, RoleId = roles.First(r => r.Name == "Admin").Id, ClaimType = "Permission",
                    ClaimValue = "CreateGameAndMap"
                },
                new()
                {
                    Id = 2, RoleId = roles.First(r => r.Name == "Admin").Id, ClaimType = "Permission",
                    ClaimValue = "UpdateGameAndMap"
                },
                new()
                {
                    Id = 3, RoleId = roles.First(r => r.Name == "Admin").Id, ClaimType = "Permission",
                    ClaimValue = "MapInteraction"
                },
                new()
                {
                    Id = 4, RoleId = roles.First(r => r.Name == "Admin").Id, ClaimType = "Permission",
                    ClaimValue = "UserManagement"
                },
                new()
                {
                    Id = 5, RoleId = roles.First(r => r.Name == "User").Id, ClaimType = "Permission",
                    ClaimValue = "MapInteraction"
                },
            };

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
            base.OnModelCreating(modelBuilder);
        }
    }
}