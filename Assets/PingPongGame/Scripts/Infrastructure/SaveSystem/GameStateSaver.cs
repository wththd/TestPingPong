using PingPongGame.Scripts.Data;

namespace PingPongGame.Scripts.SaveSystem
{
    public class GameStateSaver : IGameStateSaver
    {
        private GameConfig gameConfig;
        
        public GameStateSaver(GameConfig gameConfig)
        {
            this.gameConfig = gameConfig;
        }
        
        
        public void SaveBallConfig(BallConfig ballConfig)
        {
            gameConfig.BallConfig = ballConfig;
        }
    }
}