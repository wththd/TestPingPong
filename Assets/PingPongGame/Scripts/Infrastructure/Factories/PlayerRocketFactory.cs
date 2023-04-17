using System.Collections.Generic;
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
            transform.localPosition = Vector3.zero;
            transform.localScale = settings.Scale;
            return rocket;
        }
        public class Settings
        {
            public Transform Parent;
            public Vector3 Scale = new Vector3(2.5f, 1f, 0.2f);
            public Vector2 WallPositions;
            public float Speed = 4;
        }
    }
}