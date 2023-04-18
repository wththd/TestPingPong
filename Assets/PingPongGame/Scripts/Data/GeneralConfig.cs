using System;
using UnityEngine;

namespace PingPongGame.Scripts.Data
{
    [CreateAssetMenu]
    public class GeneralConfig : ScriptableObject
    {
        [Header("Timings")]
        public float SaveTime;
        public float SplashScreenMinimumTime;
        public float SplashScreenMaximumTime;
        [Header("Field and rocket settings")]
        [Range(0.1f, 1)]
        [Tooltip("Length of rocket divided by board width")]
        public float RocketLength;
        public int RocketSpeed;
        public float AIReactionDistance;
        [Header("Ball configuration")]
        public BallConfig DefaultBallConfig;
        [Tooltip("Force applied to ball when collide with rocket with speed more than 1")]
        public float HitForce;
        [Tooltip("Factor to keep speed smooth to target")]
        public float SmoothingFactor;
        [Tooltip("Target ball speed")]
        public float TargetSpeed;
        [Header("Level configs")]
        public int ExperienceGainedSinglePlayer;
        public int ExperienceGainedMultiPlayer;

        public void OnValidate()
        {
            DefaultBallConfig.BallColor.OnValidate();
        }
    }
}