using System.Text.Json;

namespace Demos.Azure.B2C.WinForms.Services;

public static class RoamingService
{
    private static readonly string RoamingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Demos.Azure.B2C.WinForms");

    public static async Task Set<TData>(string filePrefix, TData data)
    {
        var filePath = Path.Combine(RoamingPath, $"{filePrefix}.json");

        if (!Directory.Exists(RoamingPath))
        {
            Directory.CreateDirectory(RoamingPath);
        }

        var jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, jsonString);
    }

    public static async Task<TData?> Get<TData>(string filePrefix)
    {
        var filePath = Path.Combine(RoamingPath, $"{filePrefix}.json");

        if (File.Exists(filePath))
        {
            var jsonString = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<TData>(jsonString);
        }

        return default;
    }
}
