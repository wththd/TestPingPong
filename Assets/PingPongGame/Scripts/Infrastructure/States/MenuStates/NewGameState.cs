using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Infrastructure.States.MenuStates
{
    public class NewGameState : State<EmptyStateIntent>
    {
        private GameStateMachine gameStateMachine;
        private IUIFactory uiFactory;
        private MenuStateMachine menuStateMachine;
        private GameModeScreen screen;
        private IGameStateSaver gameStateSaver;
        
        public NewGameState(MenuStatesProvider stateProvider, GameStateMachine gameStateMachine, IUIFactory uiFactory, MenuStateMachine menuStateMachine, IGameStateSaver gameStateSaver)
        {
            stateProvider.RegisterState(this);

            this.uiFactory = uiFactory;
            this.gameStateMachine = gameStateMachine;
            this.menuStateMachine = menuStateMachine;
            this.gameStateSaver = gameStateSaver;
        }
        
        public override void EnterState()
        {
            screen = uiFactory.CreateGameModeScreen();
            screen.GameModeChosen += OnGameStateChosen;
            screen.Closed += OnScreenClosed;
        }

        private void OnGameStateChosen(GameModeScreen.GameMode mode)
        {
            gameStateSaver.CurrentConfig.ClearCurrentGameProgress();
            gameStateSaver.CurrentConfig.CurrentGameMode = mode;
            gameStateMachine.SetState<GameState>();
            ExitState();
        }

        private void OnScreenClosed()
        {
            menuStateMachine.SetState<MenuState>();
        }

        public override void ExitState()
        {
            screen.GameModeChosen -= OnGameStateChosen;
            screen.Closed -= OnScreenClosed;
            screen.Close();
        }
    }
}