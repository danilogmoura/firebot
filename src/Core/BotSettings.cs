using System.IO;
using Firebot.Bot.Automation.Core;
using Firebot.Utils;
using MelonLoader;
using UnityEngine;

namespace Firebot.Core;

public static class BotSettings
{
    private static MelonPreferences_Category _category;
    private static MelonPreferences_Entry<bool> _enable;
    private static MelonPreferences_Entry<float> _scanInterval;
    private static MelonPreferences_Entry<float> _interactionDelay;
    private static MelonPreferences_Entry<bool> _debugMode;
    private static string ObjectName => nameof(BotSettings);

    // Safe Properties
    public static bool IsEnable => _enable?.Value ?? false;
    public static float ScanInterval => Mathf.Clamp(_scanInterval.Value, 1f, 3600.0f);
    public static float InteractionDelay => Mathf.Clamp(_interactionDelay.Value, 0.5f, 5.0f);
    public static bool DebugMode => _debugMode?.Value ?? false;

    public static void Initialize()
    {
        var configPath = Path.Combine("UserData", "FirebotPreferences.cfg");

        _category = MelonPreferences.CreateCategory("firebot_settings", "Firebot Settings");
        _category.SetFilePath(configPath);

        _enable = _category.CreateEntry("Enable", false, "Enable Bot", "Enable the bot system");
        _scanInterval = _category.CreateEntry("ScanInterval", 2.0f, "Scan Interval",
            "Time between bot checks. Min: 1s, Max: 3600s");
        _interactionDelay = _category.CreateEntry("InteractionDelay", 1.0f, "Interaction Delay",
            "Delay between UI interactions. Min: 0.5s, Max: 5s");
        _debugMode = _category.CreateEntry("DebugMode", false, "Enable Debug Mode",
            "Enable debug logging for troubleshooting");

        _category.SaveToFile();
        AutomationHandler.AutoRegister(configPath);
        LogManager.Info(ObjectName, $"System Initialized. Configuration: {configPath}");
    }
}