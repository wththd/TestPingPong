using System;
using System.Threading.Tasks;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.StateMachine;

namespace PingPongGame.Scripts.Infrastructure.States.ProjectStates
{
    public class BootstrapState : State<EmptyStateIntent>
    {
        private ISceneLoader sceneLoader;
        private GameStateMachine gameStateMachine;
        
        public BootstrapState(GameStatesProvider stateProvider, ISceneLoader sceneLoader, GameStateMachine gameStateMachine)
        {
            stateProvider.RegisterState(this);
            this.sceneLoader = sceneLoader;
            this.gameStateMachine = gameStateMachine;
        }
        
        public override async void EnterState()
        {
            sceneLoader.LoadScene(Constants.StartUpSceneName);
            // We can load configs from gs here or prepare some data
            await Task.Delay(TimeSpan.FromSeconds(2));
            SetMainMenuState();
        }

        public override void ExitState()
        {
        }

        private void SetMainMenuState()
        {
            gameStateMachine.SetState<MainMenuState>();
        }
    }
}