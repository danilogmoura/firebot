using System.Collections;
using Firebot.Old._Old.TMProComponents;
using Firebot.Old._Old.Wrappers;
using Firebot.Old.Automation.Core;
using static Firebot.Old.Core.Paths.WarfrontCampaign;

namespace Firebot.Old.Automation.Enginneer;

public class WarfrontCampaignAutomation : AutomationObserver
{
    public override bool ShouldExecute() => base.ShouldExecute() && Button.Notification.IsActive();

    public override IEnumerator OnNotificationTriggered()
    {
        if (!Button.Notification.IsActive()) yield break;

        yield return Button.Notification.Click();

        ResetSchedule();

        var claimToolsButton = new ButtonWrapper(ClaimToolsButton);
        var closeButton = new ButtonWrapper(CloseButton);

        if (claimToolsButton.IsInteractable()) yield return claimToolsButton.Click();

        var timer = new TextDisplay(NextLootTimeLeft);
        ScheduleNextCheck(timer.TotalSeconds);

        yield return closeButton.Click();
    }

    private static class Button
    {
        public static readonly ButtonWrapper Notification = new(WarfrontCampaignNotification);
    }
}