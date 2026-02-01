using System.Collections;
using Firebot.Old._Old.Wrappers;
using Firebot.Old.Automation.Core;
using static Firebot.Old.Core.Paths.BattleRoot;

namespace Firebot.Old.Automation.Main;

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