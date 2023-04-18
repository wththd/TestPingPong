using System;
using System.Collections.Generic;
using UnityEngine;

namespace PingPongGame.Scripts.Data
{
    [Serializable]
    [CreateAssetMenu]
    public class MultiPlayerLevelConfigsContainer : ScriptableObject
    {
        public List<LevelConfig> MultiPlayerLevelConfigs;
        
        public void OnValidate()
        {
            foreach (var config in MultiPlayerLevelConfigs)
            {
                config.reward.BallColor.OnValidate();
            }
        }
    }
}