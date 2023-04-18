using System.Collections.Generic;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Entities;
using PingPongGame.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Factories
{
    public class PlayerRocketFactory : PlaceholderFactory<PlayerRocketFactory.Settings, PlayerRocket>
    {
        public override PlayerRocket Create(Settings settings)
        {
            var rocket = CreateInternal(
                new List<TypeValuePair>
                {
                    InjectUtil.CreateTypePair(settings)
                });

            Transform transform;
            (transform = rocket.transform).SetParent(settings.Parent);
            transform.localPosition = settings.SavedData == null ? Vector3.zero : settings.SavedData.Position.ToUnityEngineVector();
            transform.localScale = settings.Scale;

            return rocket;
        }
        public class Settings
        {
            public Transform Parent;
            public Vector3 Scale;
            public Vector2 WallPositions;
            public float Speed = 4;
            public bool IsPlayer;
            public RocketData SavedData;
        }
    }
}