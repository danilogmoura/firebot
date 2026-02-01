using UnityEngine;

namespace Firebot.GameModel.Base;

public class BasePage : GameElement
{
    public BasePage(string path, string contextName, GameElement parent = null) : base(path, contextName, parent) { }

    public BasePage(Transform root, string contextName) : base(null, contextName)
    {
        _cachedTransform = root;
    }

    public override bool IsVisible()
    {
        if (!base.IsVisible()) return false;
        if (Root.localScale.x <= 0.01f) return false;
        return !Root.TryGetComponent(out CanvasGroup group) || group.alpha != 0;
    }
}