using game_maps.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace game_maps.Application.Services;

public class FileStorageService(IWebHostEnvironment env) : IFileStorageService
{
    private readonly string[] _baseDirectory = [env.ContentRootPath, "..", "..", "game-maps.data"];

    public async Task<string> SaveFileAsync(byte[] fileData, params string[] relativePath)
    {
        var savePath = Path.Combine(GetSavePath(), Path.Combine(relativePath));
        var dirName = Path.GetDirectoryName(savePath);
        if (dirName is null) throw new Exception("no such directory");
        Directory.CreateDirectory(dirName);
        await File.WriteAllBytesAsync(savePath, fileData);
        return savePath;
    }

    public string GetSavePath(params string[] relativePath)
    {
        var baseDirectory = Path.Combine(_baseDirectory);
        return Path.Combine(baseDirectory, Path.Combine(relativePath));
    }

    public bool Exist(params string[] path)
    {
        return File.Exists(Path.Combine(GetSavePath(), Path.Combine(path)));
    }
}