using System;
using System.Collections.Generic;
using UnityEngine;

namespace PingPongGame.Scripts.Data
{
    [Serializable]
    [CreateAssetMenu]
    public class SinglePlayerLevelConfigsContainer : ScriptableObject
    {
        public List<LevelConfig> SinglePlayerLevelConfigs;
        
        public void OnValidate()
        {
            foreach (var config in SinglePlayerLevelConfigs)
            {
                config.reward.BallColor.OnValidate();
            }
        }
    }
}