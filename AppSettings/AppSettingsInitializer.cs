
using System.Text.Json;

namespace InventorySystem.AppSettings;

public sealed class AppSettingsInitializer
{
    private static readonly Lazy<AppSettingsModel> _appSettings = new (() => GetAppSettings());
    private AppSettingsInitializer()
    {

    }
    private static AppSettingsModel? GetAppSettings()
    {
        var path = "../../../AppSettings/appsettings.json";
        if (File.Exists(path))
        {
            var appSettingsJson = File.ReadAllText(path);
            return JsonSerializer.Deserialize<AppSettingsModel>(appSettingsJson);
        }
        throw new FileNotFoundException(path);
    }
    public static AppSettingsModel Instance { get { return _appSettings.Value; } }
}
