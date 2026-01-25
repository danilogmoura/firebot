using System;
using Firebot.Core;
using MelonLoader;

namespace Firebot.Utils;

public static class LogManager
{
    private const ConsoleColor TagColor = ConsoleColor.DarkCyan;
    private const ConsoleColor TextColor = ConsoleColor.Gray;
    private const ConsoleColor ErrorColor = ConsoleColor.Red;
    private const ConsoleColor DebugColor = ConsoleColor.Blue;

    public static void Info(string section, string message)
    {
        MelonLogger.Msg(TextColor, $"[{section}] {message}");
    }

    public static void Warning(string section, string message)
    {
        MelonLogger.Warning($"[{section}] {message}");
    }

    public static void Error(string section, string message)
    {
        MelonLogger.Error($"[{section}] {message}");
    }

    public static void Debug(string section, string message)
    {
        if (BotSettings.DebugMode || MelonDebug.IsEnabled())
            MelonLogger.Msg(DebugColor, $"[DEBUG] [{section}] {message}");
    }
}