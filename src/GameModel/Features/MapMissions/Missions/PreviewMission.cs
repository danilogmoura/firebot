using Firebot.GameModel.Base;
using Firebot.GameModel.Configuration;
using Firebot.GameModel.Primitives;

namespace Firebot.GameModel.Features.MapMissions.Missions;

public class PreviewMission : GameElement
{
    public PreviewMission() : base(Paths.MapMissions.Missions.Preview.Root) { }

    public GameButton CloseButton => new(Paths.MapMissions.Missions.Preview.CloseButton, this);

    public GameButton StartMissionButton => new(Paths.MapMissions.Missions.Preview.StartMissionButton, this);

    public bool IsNotEnoughSquads =>
        new BasePage(Paths.MapMissions.Missions.Preview.NotEnoughSquadsText, this).IsVisible();
}