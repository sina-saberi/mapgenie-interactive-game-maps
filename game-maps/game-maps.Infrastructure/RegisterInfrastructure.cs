using game_maps.Domain.Base;
using game_maps.Domain.Entities.User;
using game_maps.Infrastructure.Base;
using game_maps.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace game_maps.Infrastructure
{
    public static class Infrastructure
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres");
            services.AddDbContext<GameMapsDbContext>((options) => { options.UseNpgsql(connectionString); });

            services.AddIdentity<User, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<GameMapsDbContext>();

            services.AddAuthorizationBuilder()
                .AddPolicy("ElevatedRights", policy =>
                    policy.RequireRole("Admin"));
            
            services.RegisterAuthentication(configuration);
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }

        private static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secret = configuration["JwtConfig:Secret"]!;
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        // RoleClaimType = ClaimTypes.Role,
                        // NameClaimType = ClaimTypes.Name
                    };
                });
        }

        private static async Task SeedRolesAndUsersAsync(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        
            string[] roleNames = ["Admin", "User"];
        
            var roleClaims = new Dictionary<string, List<Claim>>
            {
                {
                    "Admin", [
                        new Claim("Permission", "CreateGameAndMap"),
                        new Claim("Permission", "UpdateGameAndMap"),
                        new Claim("Permission", "MapInteraction"),
                        new Claim("Permission", "UserManagement"),
                    ]
                },
                {
                    "User", [
                        new Claim("Permission", "MapInteraction"),
                    ]
                }
            };
        
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new IdentityRole(roleName);
                    await roleManager.CreateAsync(role);
        
                    if (!roleClaims.TryGetValue(roleName, out var value)) continue;
                    foreach (var claim in value)
                    {
                        await roleManager.AddClaimAsync(role, claim);
                    }
                }
                else
                {
                    var role = await roleManager.FindByNameAsync(roleName);
                    if (role == null) continue;
                    var existingClaims = await roleManager.GetClaimsAsync(role);
        
                    foreach (var claim in roleClaims[roleName].Where(claim =>
                                 !existingClaims.Any(c => c.Type == claim.Type && c.Value == claim.Value)))
                    {
                        await roleManager.AddClaimAsync(role, claim);
                    }
                }
            }
        
            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true
            };
        
            const string adminPassword = "Admin@123";
            var user = await userManager.FindByEmailAsync(adminUser.Email);
        
            if (user == null)
            {
                var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}