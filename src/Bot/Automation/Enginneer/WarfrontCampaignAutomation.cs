using System.Collections;
using Firebot.Bot.Automation.Core;
using Firebot.Bot.Component;
using static Firebot.Utils.Paths.WarfrontCampaign;

namespace Firebot.Bot.Automation.Enginneer;

public class WarfrontCampaignAutomation : AutomationObserver
{
    public override string SectionTitle => "Warfront Campaign Scrolls";

    public override bool ShouldExecute()
    {
        return base.ShouldExecute() && Button.Notification.IsActive();
    }

    public override IEnumerator OnNotificationTriggered()
    {
        if (!Button.Notification.IsActive()) yield break;

        yield return Button.Notification.Click();

        var claimToolsButton = new ButtonWrapper(ClaimToolsButton);
        var closeButton = new ButtonWrapper(CloseButton);

        if (claimToolsButton.IsInteractable()) yield return claimToolsButton.Click();

        yield return closeButton.Click();
    }

    private static class Button
    {
        public static readonly ButtonWrapper Notification = new(WarfrontCampaignNotification);
    }
}