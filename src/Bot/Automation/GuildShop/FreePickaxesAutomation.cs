using System.Collections;
using Firebot.Bot.Automation.Core;
using Firebot.Bot.Component;
using static Firebot.Utils.Paths.GuildShop;

namespace Firebot.Bot.Automation.GuildShop;

public class FreePickaxesAutomation : AutomationObserver
{
    public override string SectionTitle => "Free Pickaxes";
    public override int Priority => 25;

    public override bool ShouldExecute()
    {
        return base.ShouldExecute() && Button.Notification.IsActive();
    }

    public override IEnumerator OnNotificationTriggered()
    {
        if (!Button.Notification.IsInteractable()) yield break;

        yield return Button.Notification.Click();

        if (Button.FreePickaxeItem.IsInteractable())
            yield return Button.FreePickaxeItem.Click();

        yield return Button.Close.Click();
    }

    private static class Button
    {
        public static readonly ButtonWrapper Notification = new(FreePickaxesNotificationPath);

        public static readonly ButtonWrapper Close = new(CloseButtonPath);

        public static readonly ButtonWrapper FreePickaxeItem = new(FreePickaxeItemPath);
    }
}