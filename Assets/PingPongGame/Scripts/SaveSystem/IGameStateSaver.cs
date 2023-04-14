using PingPongGame.Scripts.Data;

namespace PingPongGame.Scripts.SaveSystem
{
    public interface IGameStateSaver
    {
        public void SaveBallConfig(BallConfig ballConfig);
    }
}