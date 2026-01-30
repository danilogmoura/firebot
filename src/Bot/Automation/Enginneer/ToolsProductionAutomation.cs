using System.Collections;
using Firebot.Bot.Automation.Core;
using Firebot.Bot.Components.Wrappers;
using static Firebot.Utils.Paths.Engineer;

namespace Firebot.Bot.Automation.Enginneer;

public class ToolsProductionAutomation : AutomationObserver
{
    public override bool ShouldExecute() => base.ShouldExecute() && Button.Notification.IsActive();

    public override IEnumerator OnNotificationTriggered()
    {
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