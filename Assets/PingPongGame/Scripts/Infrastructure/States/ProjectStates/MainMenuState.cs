using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateMachine;

namespace PingPongGame.Scripts.Infrastructure.States.ProjectStates
{
    public class MainMenuState : State<EmptyStateIntent>
    {
        private IUIFactory uiFactory;
        private ISceneLoader sceneLoader;
        
        public MainMenuState(GameStatesProvider stateProvider, ISceneLoader sceneLoader)
        {
            stateProvider.RegisterState(this);
            this.sceneLoader = sceneLoader;
        }
        public override void EnterState()
        {
            sceneLoader.LoadScene(Constants.MainMenuSceneName);
        }

        public override void ExitState()
        {
        }
    }
}