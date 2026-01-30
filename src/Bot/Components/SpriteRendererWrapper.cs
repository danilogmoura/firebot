using Firebot.Bot.Components.Wrappers;
using UnityEngine;

namespace Firebot.Bot.Components;

internal class SpriteRendererWrapper : ComponentWrapper<SpriteRenderer>
{
    public SpriteRendererWrapper(string path) : base(path) { }

    public bool Enabled() => RunSafe(() =>
        Component != null && Component.enabled && Component.gameObject.activeSelf && Component.sprite != null);
}