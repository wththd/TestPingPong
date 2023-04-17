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
            public float TargetSpeed = 12;
            public float SmoothingFactor = 0.8f;
            public float HitForce = 0.55f;
        }
    }
}