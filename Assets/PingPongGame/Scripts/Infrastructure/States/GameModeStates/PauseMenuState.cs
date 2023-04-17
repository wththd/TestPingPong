using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Infrastructure.States.GameModeStates
{
    public class PauseMenuState : State<EmptyStateIntent>
    {
        private IPauseHandler pauseHandler;
        private IUIFactory uiFactory;
        private GamePauseScreen screen;
        private GameModeStateMachine gameModeStateMachine;
        private GameStateMachine gameStateMachine;
        
        public PauseMenuState(GameModeStateProvider gameModeStatesProvider, GameModeStateMachine gameModeStateMachine, IPauseHandler pauseHandler, IUIFactory uiFactory,
            GameStateMachine gameStateMachine)
        {
            gameModeStatesProvider.RegisterState(this);
            
            this.pauseHandler = pauseHandler;
            this.uiFactory = uiFactory;
            this.gameModeStateMachine = gameModeStateMachine;
            this.gameStateMachine = gameStateMachine;
        }
        
        public override void EnterState()
        {
            pauseHandler.Pause();
            screen = uiFactory.CreateGamePauseScreen();
            screen.ContinueClicked += OnContinueClicked;
            screen.ExitClicked += OnExitClicked;
        }

        private void OnContinueClicked()
        {
            gameModeStateMachine.SetState<GamePlayingState>();
        }

        private void OnExitClicked()
        {
            ExitState();
            gameStateMachine.SetState<MainMenuState>();
        }

        public override void ExitState()
        {
            screen.ContinueClicked -= OnContinueClicked;
            screen.ExitClicked -= OnExitClicked;
            screen.Close();
        }
    }
}