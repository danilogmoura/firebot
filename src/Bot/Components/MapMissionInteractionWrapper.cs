using Firebot.Bot.Components.Wrappers;
using Il2Cpp;
using UnityEngine.EventSystems;

namespace Firebot.Bot.Components;

internal class MapMissionInteractionWrapper : ComponentWrapper<MapMissionInteraction>
{
    public MapMissionInteractionWrapper(string path) : base(path) { }

    public void OnClick() =>
        RunSafe(() =>
        {
            if (Component == null) return;

            var fakeEvent = new PointerEventData(EventSystem.current)
            {
                button = PointerEventData.InputButton.Left
            };
            Component.OnPointerClick(fakeEvent);
        });
}