using PingPongGame.Scripts.Infrastructure.Entities;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Factories
{
    public class BoardFactory : PlaceholderFactory<BoardFactory.Settings, Board>
    {
        public class Settings
        {
            public Vector2 PlaneScale;
        }
    }
}