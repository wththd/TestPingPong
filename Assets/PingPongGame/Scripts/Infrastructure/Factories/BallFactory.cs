using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Entities;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Factories
{
    public class BallFactory : PlaceholderFactory<BallFactory.Settings, Transform, Ball>
    {
        public class Settings
        {
            public Vector3 Direction;
            public float TargetSpeed;
            public float SmoothingFactor;
            public float HitForce;
            public BallConfig BallConfig;
            public BallData SavedData;
        }
    }
}