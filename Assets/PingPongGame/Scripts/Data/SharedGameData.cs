using PingPongGame.Scripts.Infrastructure.Entities;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Data
{
    public class SharedGameData
    {
        public Board Board;
        public Ball Ball;
        public Rocket PlayerRocket;
        public Rocket OppositeRocket;
        public GameModeScreen.GameMode CurrentMode;
    }
}