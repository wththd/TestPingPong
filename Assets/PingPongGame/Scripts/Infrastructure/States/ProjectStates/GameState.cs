using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.StateMachine;

namespace PingPongGame.Scripts.Infrastructure.States.ProjectStates
{
    public class GameState : State<EmptyStateIntent>
    {
        private ISceneLoader sceneLoader;
        
        public GameState(GameStatesProvider provider, ISceneLoader sceneLoader)
        {
            provider.RegisterState(this);
        }
        public override void EnterState()
        {
            sceneLoader.LoadScene(Constants.GameSceneName);
        }

        public override void ExitState()
        {
            //throw new System.NotImplementedException();
        }
    }
}