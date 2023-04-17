using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Infrastructure.States.GameModeStates
{
    public class GamePlayingState : State<EmptyStateIntent>
    {
        private IPauseHandler pauseHandler;
        private IUIFactory uiFactory;
        private GamePlayingScreen screen;
        private GameModeStateMachine gameModeStateMachine;
        
        public GamePlayingState(GameModeStateProvider gameModeStatesProvider, GameModeStateMachine gameModeStateMachine, IPauseHandler pauseHandler, IUIFactory uiFactory)
        {
            gameModeStatesProvider.RegisterState(this);
            
            this.pauseHandler = pauseHandler;
            this.uiFactory = uiFactory;
            this.gameModeStateMachine = gameModeStateMachine;
        }
        
        public override void EnterState()
        {
            pauseHandler.Resume();
            if (screen == null)
            {
                screen = uiFactory.CreateGamePlayingScreen();
                screen.MenuButtonClicked += OnMenuButtonClick;
            }
        }

        private void OnMenuButtonClick()
        {
            gameModeStateMachine.SetState<PauseMenuState>();
        }

        public override void ExitState()
        {
        }
    }
}