using Firebot.GameModel.Base;
using Firebot.GameModel.Configuration;
using Firebot.GameModel.Primitives;

namespace Firebot.GameModel.Shared;

public class TownHUD : GameElement
{
    public TownHUD() : base(Paths.Town.HUD.Root) { }

    public GameButton CloseButton => new(Paths.Town.HUD.CloseButton, this);

    public GameButton EngineerButton => new(Paths.Town.HUD.EngineerButton, this);
}