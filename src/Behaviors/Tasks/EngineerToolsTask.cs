using System.Collections;
using Firebot.Core;
using Firebot.GameModel.Features.Engineer.Tools;
using Firebot.GameModel.Shared;
using UnityEngine;
using Logger = Firebot.Core.Logger;

namespace Firebot.Behaviors.Tasks;

public class EngineerToolsTask : BotTask
{
    public override IEnumerator Execute()
    {
        new MainHUD().TownButton.Click();
        yield return new WaitForSeconds(BotSettings.InteractionDelay);

        var townHUD = new TownHUD();
        if (!townHUD.EngineerButton.IsClickable())
        {
            Logger.Debug("Engineer button is not clickable, skipping.");
            townHUD.CloseButton.Click();
            yield return new WaitForSeconds(BotSettings.InteractionDelay);
            yield break;
        }

        townHUD.EngineerButton.Click();
        yield return new WaitForSeconds(BotSettings.InteractionDelay);

        new GaragePopup().EngineerButton.Click();
        yield return new WaitForSeconds(BotSettings.InteractionDelay);

        var engineerSubmenu = new EngineerSubmenu();
        if (!engineerSubmenu.IsVisible())
        {
            Logger.Debug("Engineer submenu is not visible, skipping.");
            yield break;
        }

        var claimToolsButton = engineerSubmenu.ClaimToolsButton;
        if (claimToolsButton.IsClickable())
        {
            claimToolsButton.Click();
            yield return new WaitForSeconds(BotSettings.InteractionDelay);
            Logger.Info("Claimed engineer tools.");
        }

        NextRunTime = engineerSubmenu.FindNextRunTime;
        Logger.Debug($"Engineer tools are on cooldown, next run time: {engineerSubmenu.FindNextRunTime}");

        engineerSubmenu.CloseButton.Click();
        yield return new WaitForSeconds(BotSettings.InteractionDelay);

        townHUD.CloseButton.Click();
        yield return new WaitForSeconds(BotSettings.InteractionDelay);
    }
}