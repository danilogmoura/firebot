using Il2CppTMPro;
using UnityEngine;

namespace Firebot.GameModel.Base;

public class BaseGameText<T> : GameElement where T : TMP_Text
{
    private T _cachedComponent;

    public BaseGameText(string path, string contextName, GameElement parent = null)
        : base(path, contextName, parent) { }

    public BaseGameText(Transform root, string contextName)
        : base(null, contextName)
    {
        _cachedTransform = root;
    }

    public T Component
    {
        get
        {
            if (_cachedComponent != null && _cachedComponent.gameObject != null)
                return _cachedComponent;

            if (!TryGetComponent(out _cachedComponent) && IsVisible())
                Debug($"Component of type {typeof(T).Name} not found at path: {Path}");

            return _cachedComponent;
        }
    }

    public string Text
    {
        get
        {
            if (!IsVisible()) return string.Empty;

            var comp = Component;
            if (comp == null || !comp.isActiveAndEnabled) return string.Empty;

            var text = comp.GetParsedText();
            Debug($"Text at path '{Path}': {text}");
            return text;
        }
    }
}