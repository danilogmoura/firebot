using System.Collections;
using System.Linq;
using Firebot.Bot.Automation.Core;
using Firebot.Bot.Component;
using UnityEngine;
using static Firebot.Utils.Paths.FirestoneResearch;
using static Firebot.Utils.StringUtils;

namespace Firebot.Bot.Automation.Library;

internal class FirestoneResearchAutomation : AutomationObserver
{
    public override bool ShouldExecute() => base.ShouldExecute() && Buttons.Notification.IsActive();

    public override IEnumerator OnNotificationTriggered()
    {
        if (!Buttons.Notification.IsInteractable()) yield break;

        yield return Buttons.Notification.Click();

        if (!Panel.SubmenusWrapper.IsActive() && Panel.SelectResearch.IsActive())
            yield break;

        if (Panel.Slot0.IsActive() && Buttons.ButtonClainSlot0.IsInteractable())
            yield return Buttons.ButtonClainSlot0.Click();

        if (Panel.Slot1.IsActive() && Buttons.ButtonClainSlot1.IsInteractable())
            yield return Buttons.ButtonClainSlot1.Click();

        var submenus = Panel.SubmenusWrapper.GetChildren();

        foreach (var tree in submenus)
        {
            if (!tree.Name.StartsWith("tree") || !tree.IsActive()) continue;

            var slots = tree.GetChildren();

            foreach (var slot in slots
                         .Where(slot => slot.IsActive() && Panel.SelectResearch.IsActive()))
            {
                yield return OpenPopup(JoinPath(SubmenusTreePath, tree.Name, slot.Name));

                if (Panel.SubmenusWrapper.IsActive() && Buttons.StartResearch.IsInteractable())
                    yield return Buttons.StartResearch.Click();
            }
        }

        yield return Buttons.Close.Click();
    }

    private static IEnumerator OpenPopup(string paths)
    {
        var button = new ButtonWrapper(paths);
        if (!button.IsInteractable()) yield break;
        yield return button.Click();
    }

    private readonly struct ResearchSlotWrapper
    {
        private readonly Transform _root;

        public string Name { get; }

        public ResearchSlotWrapper(Transform t)
        {
            _root = t;
            Name = t.name;
        }

        public bool IsValid()
        {
            if (_root == null || !_root.gameObject.activeInHierarchy) return false;
            if (!Name.StartsWith("firestoneResearch")) return false;

            var bar = _root.Find("progressBarBg");
            var glow = _root.Find("glow");

            return bar != null && bar.gameObject.activeInHierarchy &&
                   (glow == null || !glow.gameObject.activeInHierarchy);
        }
    }

    private static class Panel
    {
        public static readonly ObjectWrapper SubmenusWrapper = new(SubmenusTreePath);
        public static readonly ObjectWrapper Slot0 = new(ResearchPanelDownPath + "/researchSlot0");
        public static readonly ObjectWrapper Slot1 = new(ResearchPanelDownPath + "/researchSlot1");
        public static readonly ObjectWrapper SelectResearch = new(SelectResearchTablePath);
    }

    private static class Buttons
    {
        public static readonly ButtonWrapper Notification = new(FirestoneResearchNotificationPath);

        public static readonly ButtonWrapper ButtonClainSlot0 =
            new(JoinPath(ResearchPanelDownPath, "researchSlot0/container/claimButton"));

        public static readonly ButtonWrapper ButtonClainSlot1 =
            new(JoinPath(ResearchPanelDownPath, "researchSlot1/container/claimButton"));

        public static readonly ButtonWrapper Close = new(MissionCloseButton);
        public static readonly ButtonWrapper StartResearch = new(PopupActivateButton);
    }
}