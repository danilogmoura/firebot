using UnityEngine;

namespace Firebot.Bot.Component
{
    internal class SpriteRendererWrapper : ComponentWrapper<SpriteRenderer>
    {
        public SpriteRendererWrapper(string path) : base(path)
        {
        }

        public bool Enabled()
        {
            return Component != null && Component.enabled && Component.gameObject.activeSelf &&
                   Component.sprite != null;
        }
    }
}