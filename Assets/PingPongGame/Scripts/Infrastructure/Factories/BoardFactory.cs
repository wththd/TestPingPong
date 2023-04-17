using System.Numerics;
using PingPongGame.Scripts.Infrastructure.UIElements;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Factories
{
    public class BoardFactory : PlaceholderFactory<BoardFactory.Settings, Board>
    {
        public class Settings
        {
            public Vector2 PlaneScale = new Vector2(0.9f, 1.6f);
            public Vector2 RocketRelativeScale = new Vector2(2.5f, 0.2f);
            public GameModeScreen.GameMode Mode;
        }
    }
}