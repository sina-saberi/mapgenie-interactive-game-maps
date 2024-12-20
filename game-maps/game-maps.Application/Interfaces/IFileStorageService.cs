namespace game_maps.Application.Interfaces;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(byte[] fileData, params string[] relativePath);
    string GetSavePath(params string[] relativePath);
    bool Exist(params string[] path);
}