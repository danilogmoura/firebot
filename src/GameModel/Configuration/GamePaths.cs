namespace Firebot.GameModel;

public static class GamePaths
{
    private const string BaseCanvas = "menusRoot/menuCanvasParent/SafeArea/menuCanvas";

    public static class Menus
    {
        private const string Root = BaseCanvas + "/menus";

        public const string TreeOfLife = Root + "/TreeOfLife";
        public const string TownGuild = Root + "/TownGuild";
        public const string TownIrongard = Root + "/TownIrongard";
        public const string ExoticMerchant = Root + "/ExoticMerchant";
        public const string MagicQuarters = Root + "/MagicQuarters";
        public const string WorldMap = Root + "/WorldMap";
    }

    public static class Events
    {
        private const string Root = BaseCanvas + "/events";
        public const string EventManager = Root + "/EventManager";
        public const string DecoratedShop = Root + "/DecoratedHeroesShop";
        public const string MiniEvents = Root + "/MiniEvents";
    }

    public static class Popups
    {
        private const string Root = BaseCanvas + "/popups";
        public const string Expeditions = Root + "/Expeditions";
        public const string GuildBank = Root + "/GuildBank";
        public const string PreviewMission = Root + "/PreviewMission";
        public const string MissionRewards = Root + "/MissionRewards";
    }

    public static class Notifications
    {
        private const string Root = "battleRoot/battleMain/battleCanvas/SafeArea";
        public const string NotificationGrid = Root + "/leftSideUI/notifications/Viewport/grid";
    }
}