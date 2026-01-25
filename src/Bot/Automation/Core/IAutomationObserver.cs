using System.Collections;
using Firebot.Utils;
using MelonLoader;

namespace Firebot.Bot.Automation.Core;

public abstract class AutomationObserver
{
    private MelonPreferences_Entry<bool> _enabledEntry;

    public abstract string SectionTitle { get; }

    public string SectionId => SectionTitle.ToLower().Replace(" ", "_");

    public bool IsEnabled => _enabledEntry != null && _enabledEntry.Value;

    // We define 50 as the default "middle ground".
    // Virtual allows child classes to override it if they want.
    public virtual int Priority => 50;

    public void InitializeConfig(string filePath)
    {
        if (_enabledEntry != null) return;

        var category = MelonPreferences.CreateCategory(SectionId, $"{SectionTitle} Settings");
        category.SetFilePath(filePath);

        _enabledEntry = category.CreateEntry("enabled", false, "Enable Module",
            $"Enable the {SectionTitle} automation module");

        OnConfigure(category);
        category.SaveToFile();
    }

    protected virtual void OnConfigure(MelonPreferences_Category category)
    {
        // Optional for derived classes
    }

    public virtual bool ShouldExecute()
    {
        return IsEnabled;
    }

    public abstract IEnumerator OnNotificationTriggered();

    protected void Log(string message)
    {
        LogManager.Info(SectionTitle, message);
    }

    protected void LogWarning(string message)
    {
        LogManager.Warning(SectionTitle, message);
    }

    protected void LogError(string message)
    {
        LogManager.Error(SectionTitle, message);
    }

    protected void LogDebug(string message)
    {
        LogManager.Debug(SectionTitle, message);
    }
}