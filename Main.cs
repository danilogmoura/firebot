using System;
using System.Collections;
using FireBot.Bot.Automation.Enginneer;
using FireBot.Bot.Automation.Expedition;
using FireBot.Bot.Automation.Library;
using FireBot.Bot.Automation.MagicQuarters;
using FireBot.Bot.Automation.Main;
using FireBot.Bot.Automation.Mission;
using FireBot.Bot.Automation.Oracle;
using FireBot.Config;
using FireBot.Utils;
using MelonLoader;
using UnityEngine;

namespace FireBot
{
    public static class BuildInfo
    {
        public const string Name = "FireBot";
        public const string Description = "";
        public const string Author = "danilogmoura";
        public const string Company = null;
        public const string Version = "1.0.0";
    }

    public class Main : MelonMod
    {
        private const float MissionLogIntervalSeconds = 60f;
        private bool _isBotRunning;
        private float _timer;

        public override void OnInitializeMelon()
        {
            BotSettings.Initialize();
        }

        public override void OnLateInitializeMelon()
        {
            LogManager.Initialize(LoggerInstance);
            _timer = MissionLogIntervalSeconds;
        }

        public override void OnUpdate()
        {
            if (!BotSettings.IsBotEnabled.Value) return;

            _timer -= Time.deltaTime;

            if (!(_timer <= 0f)) return;
            
            _timer = MissionLogIntervalSeconds;
            if (!_isBotRunning) MelonCoroutines.Start(RunAllSequentially());
        }

        private IEnumerator RunAllSequentially()
        {
            _isBotRunning = true;
            LogManager.Header($"Starting automations - {DateTime.Now:HH:mm:ss}");

            try
            {
                yield return OfflineProgressAutomation.Process();
                yield return ToolsProductionAutomation.Process();
                yield return WarfrontCampaignAtomation.Process();
                yield return MissionMapAutomation.Process();
                yield return ExpeditionAutomation.Process();
                yield return FirestoneResearchAutomation.Process();
                yield return OracleRitualsAutomation.Process();
                yield return GuardianTrainingAutomation.Process();
            }
            finally
            {
                _isBotRunning = false;
                LogManager.WriteLine();
            }
        }
    }
}