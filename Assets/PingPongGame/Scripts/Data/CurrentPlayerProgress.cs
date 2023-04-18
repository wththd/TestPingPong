using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PingPongGame.Scripts.Data
{
    [DataContract]
    public class CurrentPlayerProgress
    {
        public event Action<BallConfig> Rewarded;
        
        [DataMember(Name ="current_level_progress")]
        public int CurrentLevelExp;
        [DataMember(Name = "current_level")]
        public int CurrentLevel;
        
        [JsonIgnore]
        public List<LevelConfig> levelConfigs;
        
        public bool IsMaxLevel => CurrentLevel == levelConfigs.Count;
        public int CurrentLevelProgress => CurrentLevelExp / levelConfigs[CurrentLevel].LevelExp;

        public void AddProgress(int progress)
        {
            CurrentLevelExp += progress;
            RefreshPlayerProgress();
        }

        private void RefreshPlayerProgress()
        {
            if (!IsMaxLevel)
            {
                var currentConfig = levelConfigs[CurrentLevel];
                while (currentConfig.LevelExp < CurrentLevelExp)
                {
                    CurrentLevelExp -= currentConfig.LevelExp;
                    Rewarded?.Invoke(currentConfig.reward);
                    CurrentLevel++;
                }
            }
        }

        public void SetLevelConfigs(List<LevelConfig> configs)
        {
            levelConfigs = configs;
            // Check if configs changed and user should be leveled up
            RefreshPlayerProgress();
        }
    }
}