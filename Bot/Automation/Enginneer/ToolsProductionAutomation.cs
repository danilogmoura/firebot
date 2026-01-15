using System.Collections;
using FireBot.Bot.Component;
using FireBot.Utils;
using static FireBot.Utils.Paths.Engineer;

namespace FireBot.Bot.Automation.Enginneer
{
    public static class ToolsProductionAutomation
    {
        public static IEnumerator Process()
        {
            var engineerNotif = new ButtonWrapper(GridNotification);
            if (!engineerNotif.IsActive()) yield break;

            LogManager.SubHeader("Tools Production");
            yield return engineerNotif.Click();

            var caimToolsButton = new ButtonWrapper(ClaimToolsButton);

            if (caimToolsButton.IsInteractable()) yield return caimToolsButton.Click();

            var closeButton = new ButtonWrapper(CloseButton);
            yield return closeButton.Click();
        }
    }
}