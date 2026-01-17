using System.Collections;
using FireBot.Bot.Automation.Core;
using FireBot.Bot.Component;
using static FireBot.Utils.Paths.BattleRoot;

namespace FireBot.Bot.Automation.Main
{
    internal class OfflineProgressAutomation : AutomationObserver
    {
        private static readonly ObjectWrapper Popup = new ObjectWrapper(OfflineProgressPopup);
        private static readonly ButtonWrapper ClaimButton = new ButtonWrapper(OfflineProgressPopupClaimButton);

        public override bool ToogleCondition()
        {
            return Popup.IsActive();
        }

        public override IEnumerator OnNotificationTriggered()
        {
            yield return ClaimButton.Click();
        }
    }
}