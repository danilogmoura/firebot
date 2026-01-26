using System.Collections;
using Firebot.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Firebot.Bot.Component;

internal class ButtonWrapper : ComponentWrapper<Button>
{
    public ButtonWrapper(string path) : base(path) { }

    public bool IsInteractable() => IsActive() && ComponentCached.enabled && ComponentCached.interactable;

    public IEnumerator Click() => Click(BotSettings.InteractionDelay);

    private IEnumerator Click(float delay)
    {
        if (!IsInteractable())
            yield break;

        ComponentCached.Select();
        ComponentCached.onClick.Invoke();

        if (delay > 0) yield return new WaitForSeconds(delay);
    }
}