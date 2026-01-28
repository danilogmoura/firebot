using System;
using System.Collections;
using Firebot.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Firebot.Bot.Components.Wrappers;

internal class ButtonWrapper : ComponentWrapper<Button>
{
    public ButtonWrapper(string path) : base(path) { }

    public bool IsInteractable() => IsActive() && Component.enabled && Component.interactable;

    public IEnumerator Click() => Click(BotSettings.InteractionDelay);

    private IEnumerator Click(float delay)
    {
        var success = ExecuteSafe(() =>
        {
            if (!IsInteractable())
                throw new InvalidOperationException("Button is not interactable.");

            Component.Select();
            Component.onClick.Invoke();

            Log.Debug($"Clicked button at path: {Path}");
            return true;
        });

        if (success && delay > 0) yield return new WaitForSeconds(delay);
    }
}