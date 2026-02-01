using Firebot.GameModel.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Firebot.GameModel.Primitives;

public class GameButton : GameElement
{
    public GameButton(string path, string contextName, GameElement parent = null) :
        base(path, contextName, parent) { }

    public GameButton(Transform root, string contextName) : base(null, contextName)
    {
        _cachedTransform = root;
    }

    public override bool IsVisible()
    {
        if (!base.IsVisible()) return false;
        return !TryGetComponent(out CanvasGroup group) || group.alpha != 0;
    }

    public bool IsClickable() => IsVisible() && Root.TryGetComponent(out Button button) && button.interactable;

    public void Click()
    {
        if (!IsVisible())
        {
            Debug($"Button at path '{Path}' is not visible.");
            return;
        }

        if (TryGetComponent(out Button button) && button.interactable)
        {
            Debug($"Button at path '{Path}' is interactable.");
            button.onClick.Invoke();
        }
        else
            Debug($" Button at path '{Path}' is not interactable.");
    }
}