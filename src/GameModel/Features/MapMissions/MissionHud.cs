using Firebot.GameModel.Base;
using Firebot.GameModel.Configuration;
using Firebot.GameModel.Primitives;

namespace Firebot.GameModel.Features.MapMissions;

public class MissionHud : GameElement
{
    public MissionHud() : base(Paths.MapMissions.Hub.Root) { }

    public GameButton CloseButton => new(Paths.MapMissions.Hub.CloseButton, this);

    public GameText MissionRefresh => new(Paths.MapMissions.Hub.MissionRefresh, this);
}