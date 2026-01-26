using System;
using Firebot.Utils;

namespace Firebot.Bot.Component.TextMeshPro;

public class TextUI
{
    private readonly string _path;
    private MappedObjectBase _activeWrapper;

    public TextUI(string path)
    {
        _path = path;
    }

    public TimeSpan Time => TimeParser.Parse(Text);
    public double TotalSeconds => Time.TotalSeconds;
    public string Text => GetText();

    private string GetText()
    {
        if (string.IsNullOrEmpty(_path)) return string.Empty;

        if (_activeWrapper != null && _activeWrapper.IsActive()) return ExtractText(_activeWrapper);

        var ugui = new TextMeshProUGUIWrapper(_path);
        if (ugui.IsActive())
        {
            _activeWrapper = ugui;
            return ugui.Text;
        }

        var tmpro = new TextMeshProWrapper(_path);
        if (!tmpro.IsActive()) return string.Empty;

        _activeWrapper = tmpro;
        return tmpro.Text;
    }

    private static string ExtractText(MappedObjectBase wrapper) =>
        wrapper switch
        {
            TextMeshProUGUIWrapper ugui => ugui.Text,
            TextMeshProWrapper tmpro => tmpro.Text,
            _ => string.Empty
        };
}