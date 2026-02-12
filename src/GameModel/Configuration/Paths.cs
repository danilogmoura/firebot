namespace Firebot.GameModel.Configuration;

public static class Paths
{
    private const string BattleRootSafeArea = "battleRoot/battleMain/battleCanvas/SafeArea";

    private const string MenusRoottSafeArea = "menusRoot/menuCanvasParent/SafeArea";

    public static class Popups
    {
        public const string CloseButton = "/bg/closeButton";
    }

    public static class Hud
    {
        public const string Root = BattleRootSafeArea;

        public const string TownButton = "/rightSideUI/menuButtons/townButton";

        public const string MapButton = "/rightSideUI/menuButtons/mapButton";

        public const string GuildButton = "/rightSideUI/menuButtons/guildButton";

        public const string StoreButton = "/rightSideUI/menuButtons/storeButton";

        public const string PathOfGloryButton = "/bottomSideUIDesktop/pathOfGloryButton";

        public const string EventsButton = "/bottomSideUIDesktop/eventsButton";
    }

    public static class MapMissions
    {
        public static class Hub
        {
            public const string Root = MenusRoottSafeArea + "/menuCanvas/menus/WorldMap";

            public const string CloseButton = "/closeButton";

            public const string MissionRefresh =
                "/submenus/mapMissionsSubmenu/bottomLeftUI/missionRefreshCanvas/missionRefreshBg/missionRefreshText";

            public const string WarfrontCampaignButton = "/submenuButtons/warfrontCampaignButton";
        }

        public static class Missions
        {
            public static class ActiveMissions
            {
                public const string Root = MenusRoottSafeArea + "/menuCanvas/menus/WorldMap";

                public const string ActiveMissionsGrid =
                    "/submenus/mapMissionsSubmenu/activeMissionsCanvas/activeMissions/Viewport/grid";

                public const string MissionProgress = "/missionProgress/activeMissionProgressText";
            }

            public static class Preview
            {
                public const string Root = MenusRoottSafeArea + "/menuCanvas/popups/PreviewMission";

                public const string CloseButton = "/bg/closeButton";

                public const string SpeedUpButton = "/bg/managementBg/container/speedUpButton";

                public const string SpeedUpButtonIcon = "/currencyIcon";

                public const string StartMissionButton = "/bg/managementBg/container/startMissionButton";

                public const string MissionProgress =
                    "/bg/rewardBg/previewMissionTime/previewBar/missionProgress/activeMissionProgressText";

                public const string NotEnoughSquadsText = "/bg/managementBg/previewMissionNotEnoughSquads";
            }

            public static class MapPin
            {
                public const string Root = "menusRoot/mapRoot/mapElements/missions";

                public const string MissionActiveIcon = "/missionActiveIcon";

                public const string MissionTimeRequirement = "/missionBg/missionTimeBg/missionTimeReq";

                public const string CompletedTick = "/missionBg/completedTick";
            }
        }

        public static class WarfrontCampaign
        {
            public static class Loot
            {
                public const string Root = MenusRoottSafeArea +
                                           "/menuCanvas/menus/WorldMap/submenus/warfrontCampaignSubmenu/loot";

                public const string NextLootTimeLeft = "/nextLootTimeLeft";

                public const string ClaimToolsButton = "/claimButton";
            }
        }
    }
}