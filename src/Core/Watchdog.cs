using System.Collections;
using Firebot.GameModel.Primitives;
using UnityEngine;

namespace Firebot.Core;

public static class Watchdog
{
    private static readonly string[] NuisancePaths =
    {
        "menusRoot/menuCanvasParent/SafeArea/menuCanvas/popups/OfflineProgress/bg/collectButton",
        "menusRoot/menuCanvasParent/SafeArea/menuCanvas/events/AnniversaryEventPromotional/bg/closeButton",
        "menusRoot/menuCanvasParent/SafeArea/menuCanvas/events/LoveIsInTheAirPromotion/bg/closeButton"
    };

    public static IEnumerator ForceClearAll()
    {
        for (var i = 0; i < 3; i++)
        {
            foreach (var path in NuisancePaths)
            {
                var btn = new GameButton(path);

                if (!btn.IsVisible()) continue;
                Debug.Log($"[Watchdog] Fechando popup: {path}");
                btn.Click();
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}