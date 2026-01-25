using System.Collections;
using Firebot.Bot.Automation.Core;
using Firebot.Bot.Component;
using static Firebot.Utils.Paths.Engineer;

namespace Firebot.Bot.Automation.Enginneer;

public class ToolsProductionAutomation : AutomationObserver
{
    public override string SectionTitle => "Tools Production";

    public override bool ShouldExecute()
    {
        return base.ShouldExecute() && Button.Notification.IsActive();
    }

    public override IEnumerator OnNotificationTriggered()
    {
        if (!Button.Notification.IsActive()) yield break;

        yield return Button.Notification.Click();

        var caimToolsButton = new ButtonWrapper(ClaimToolsButton);

        if (caimToolsButton.IsInteractable()) yield return caimToolsButton.Click();

        var closeButton = new ButtonWrapper(CloseButton);
        yield return closeButton.Click();
    }

    private static class Button
    {
        public static readonly ButtonWrapper Notification = new(EngineerGridNotification);
    }
}