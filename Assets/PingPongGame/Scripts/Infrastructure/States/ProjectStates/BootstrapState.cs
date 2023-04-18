using System;
using System.Threading.Tasks;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateMachine;

namespace PingPongGame.Scripts.Infrastructure.States.ProjectStates
{
    public class BootstrapState : State<EmptyStateIntent>, IDisposable
    {
        private ISceneLoader sceneLoader;
        private GameStateMachine gameStateMachine;
        private IGameStateSaver gameStateSaver;
        private GeneralConfig generalConfig;
        private bool disposed;
        
        public BootstrapState(GameStatesProvider stateProvider, ISceneLoader sceneLoader, GameStateMachine gameStateMachine,
            IGameStateSaver gameStateSaver, GeneralConfig generalConfig)
        {
            stateProvider.RegisterState(this);
            this.sceneLoader = sceneLoader;
            this.gameStateMachine = gameStateMachine;
            this.gameStateSaver = gameStateSaver;
            this.generalConfig = generalConfig;
        }
        
        public override async void EnterState()
        {
            sceneLoader.LoadScene(Constants.StartUpSceneName);
            var minimumWaitTask = Task.Delay(TimeSpan.FromSeconds(generalConfig.SplashScreenMinimumTime));
            var maximumWaitTask = Task.Delay(TimeSpan.FromSeconds(generalConfig.SplashScreenMaximumTime));
            // We can load configs from gs here or prepare some data
            await Task.WhenAll(minimumWaitTask, Task.WhenAny(gameStateSaver.Load(), maximumWaitTask));
            // Prevent errors while leaving the game in async
            if (!disposed)
            {
                SetMainMenuState();
            }
        }

        public override void ExitState()
        {
        }

        private void SetMainMenuState()
        {
            gameStateMachine.SetState<MainMenuState>();
        }

        public void Dispose()
        {
            disposed = true;
        }
    }
}