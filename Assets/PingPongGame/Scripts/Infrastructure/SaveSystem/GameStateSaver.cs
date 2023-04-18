using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PingPongGame.Scripts.Data;

namespace PingPongGame.Scripts.Infrastructure.SaveSystem
{
    public class GameStateSaver : IGameStateSaver, IDisposable
    {
        private GameConfig gameConfig;
        private GeneralConfig generalConfig;
        private List<ISavable> savables = new();
        private IDataSaver<GameConfig> dataSaver;
        private SinglePlayerLevelConfigsContainer singlePlayerLevelConfigsContainer;
        private MultiPlayerLevelConfigsContainer multiPlayerLevelConfigsContainer;
        private bool disposed;

        public GameConfig CurrentConfig => gameConfig;

        public GameStateSaver(GeneralConfig generalConfig, IDataSaver<GameConfig> dataSaver, SinglePlayerLevelConfigsContainer singlePlayerLevelConfigsContainer,
            MultiPlayerLevelConfigsContainer multiPlayerLevelConfigsContainer)
        {
            this.generalConfig = generalConfig;
            this.dataSaver = dataSaver;
            this.singlePlayerLevelConfigsContainer = singlePlayerLevelConfigsContainer;
            this.multiPlayerLevelConfigsContainer = multiPlayerLevelConfigsContainer;
        }

        public async Task Load()
        {
            gameConfig = await dataSaver.Load();
            if (!disposed)
            {
                gameConfig.BallConfig ??= generalConfig.DefaultBallConfig;
                gameConfig.CurrentPlayerSingleProgress.Rewarded += OnRewardedWithConfig;
                gameConfig.CurrentPlayerMultiplayerProgress.Rewarded += OnRewardedWithConfig;

                gameConfig.CurrentPlayerMultiplayerProgress.SetLevelConfigs(multiPlayerLevelConfigsContainer
                    .MultiPlayerLevelConfigs);
                gameConfig.CurrentPlayerSingleProgress.SetLevelConfigs(singlePlayerLevelConfigsContainer
                    .SinglePlayerLevelConfigs);
                // First render to speed up next savings
                SaveData();
            }
        }

        private void OnRewardedWithConfig(BallConfig ballConfig)
        {
            gameConfig.Rewards.Add(ballConfig);
            SaveData();
        }

        public void RegisterSavable(ISavable savable)
        {
            savables.Add(savable);
        }

        public void UnregisterSavable(ISavable savable)
        {
            savables.Remove(savable);
        }

        public void AddSingleLevelProgress()
        {
            gameConfig.CurrentPlayerSingleProgress.AddProgress(generalConfig.ExperienceGainedSinglePlayer);
            SaveData();
        }

        public void AddMultiplayerLevelProgress()
        {
            gameConfig.CurrentPlayerMultiplayerProgress.AddProgress(generalConfig.ExperienceGainedMultiPlayer);
            SaveData();
        }
        
        public void Save()
        {
            foreach (var savable in savables)
            {
                savable.Save(gameConfig);
            }

            SaveData();
        }

        public void SaveData()
        {
            dataSaver.Save(gameConfig);
        }
        
        
        public void SaveBallConfig(BallConfig ballConfig)
        {
            gameConfig.BallConfig = ballConfig;
            SaveData();
        }

        public void Dispose()
        {
            disposed = true;
            Save();
        }
    }
}