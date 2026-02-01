using Firebot.Old._Old.Wrappers;
using UnityEngine;

namespace Firebot.Old._Old;

internal class SpriteRendererWrapper : ComponentWrapper<SpriteRenderer>
{
    public SpriteRendererWrapper(string path) : base(path) { }

    public bool Enabled() => RunSafe(() =>
        Component != null && Component.enabled && Component.gameObject.activeSelf && Component.sprite != null);
}