using System.Collections;
using Firebot.Bot.Automation.Core;
using Firebot.Bot.Components.Wrappers;
using static Firebot.Utils.Paths.BattleRoot;

namespace Firebot.Bot.Automation.Main;

internal class OfflinePopupProgressAutomation : AutomationObserver
{
    private static readonly TransformWrapper Popup = new(OfflineProgressPopup);
    private static readonly ButtonWrapper ClaimButton = new(OfflineProgressPopupClaimButton);

    private bool _hasExecutedSuccessfully;

    public override int Priority => 20;

    public override bool ShouldExecute() => !_hasExecutedSuccessfully && base.ShouldExecute() && Popup.IsActive();

    public override IEnumerator OnNotificationTriggered()
    {
        yield return ClaimButton.Click();
        _hasExecutedSuccessfully = true;
    }
}