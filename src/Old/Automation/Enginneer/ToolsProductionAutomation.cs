using System.Collections;
using Firebot.Old._Old.Wrappers;
using Firebot.Old.Automation.Core;
using static Firebot.Old.Core.Paths.Engineer;

namespace Firebot.Old.Automation.Enginneer;

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