using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace game_maps.Infrastructure.Data;

public class GameMapsDbContextFactory: IDesignTimeDbContextFactory<GameMapsDbContext>
{
    public GameMapsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("appsettings.json") 
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<GameMapsDbContext>();
        var connectionString = configuration.GetConnectionString("Postgres");

        optionsBuilder.UseNpgsql(connectionString);

        return new GameMapsDbContext(optionsBuilder.Options);
    }
}