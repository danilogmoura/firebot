using System;
using Firebot.GameModel.Base;
using Firebot.GameModel.Configuration;
using Firebot.GameModel.Primitives;

namespace Firebot.GameModel.Features.MapMissions.Missions;

public class ActiveMissions : GameElement
{
    public ActiveMissions() : base(Paths.MapMissions.ActiveMissions.Root +
                                   Paths.MapMissions.ActiveMissions.ActiveMissionsGrid) { }

    public DateTime FindNextRunTime
    {
        get
        {
            var earliestDate = DateTime.MaxValue;
            var foundAny = false;

            foreach (var gameElement in GetChildren())
            {
                if (!gameElement.IsVisible()) continue;

                var timer = new GameText(gameElement.Root, Paths.MapMissions.ActiveMissions.MissionProgress);
                var missionFinishTime = timer.Time;

                if (missionFinishTime < earliestDate && missionFinishTime > DateTime.Now)
                {
                    earliestDate = missionFinishTime;
                    foundAny = true;
                }
            }

            return foundAny ? earliestDate.AddSeconds(30) : DateTime.Now.AddMinutes(1);
        }
    }
}