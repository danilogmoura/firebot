using Firebot.GameModel.Base;
using Firebot.GameModel.Configuration;
using Firebot.GameModel.Primitives;

namespace Firebot.GameModel.Features.MapMissions.Missions;

public class PreviewMission : GameElement
{
    public PreviewMission() : base(Paths.MapMissions.Preview.Root) { }

    public GameButton CloseButton => new(Paths.MapMissions.Preview.CloseButton, this);

    public GameButton StartMissionButton => new(Paths.MapMissions.Preview.StartMissionButton, this);

    public bool IsNotEnoughSquads => new BasePage(Paths.MapMissions.Preview.NotEnoughSquadsText, this).IsVisible();
}