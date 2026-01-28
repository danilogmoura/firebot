using Firebot.Bot.Components.Wrappers;
using Il2CppTMPro;
using UniverseLib.Utility;

namespace Firebot.Bot.Components.TMProComponents;

internal class BaseTextWrapper<T> : ComponentWrapper<T> where T : TMP_Text
{
    protected BaseTextWrapper(string path) : base(path) { }

    public string Text => GetText();

    private string GetText() => ExecuteSafe(() => Component?.GetParsedText() ?? string.Empty);

    public bool Contains(string textToCheck) =>
        !string.IsNullOrEmpty(Text) && Text.Trim().ContainsIgnoreCase(textToCheck.Trim());
}