using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateIntents;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Infrastructure.States.GameModeStates
{
    public class GameEndState : State<EmptyStateIntent>
    {
        private IPauseHandler pauseHandler;
        private GameEndScreen screen;
        private IUIFactory uiFactory;
        private GameStateMachine gameStateMachine;
        private GameModeStateMachine gameModeStateMachine;
        private IGameStateSaver gameStateSaver;

        public GameEndState(GameModeStateProvider gameModeStatesProvider, IPauseHandler pauseHandler, IUIFactory uiFactory,
            GameStateMachine gameStateMachine, GameModeStateMachine gameModeStateMachine, IGameStateSaver gameStateSaver)
        {
            gameModeStatesProvider.RegisterState(this);

            this.pauseHandler = pauseHandler;
            this.uiFactory = uiFactory;
            this.gameStateMachine = gameStateMachine;
            this.gameModeStateMachine = gameModeStateMachine;
            this.gameStateSaver = gameStateSaver;
        }
        public override void EnterState()
        {
            pauseHandler.Pause();
            gameStateSaver.CurrentConfig.ClearCurrentGameProgress();
            gameStateSaver.SaveData();
            screen = uiFactory.CreateGameEndScreen();
            screen.StartNewGameClicked += OnStartNewGameClicked;
            screen.ExitMainMenuClicked += OnExitMainMenuClicked;
        }

        private void OnExitMainMenuClicked()
        {
            ExitState();
            gameStateMachine.SetState<MainMenuState>();
        }

        private void OnStartNewGameClicked()
        {
            gameModeStateMachine.SetState<LoadLevelState, LoadLevelStateIntent>(new LoadLevelStateIntent
            {
                GameMode = gameStateSaver.CurrentConfig.CurrentGameMode
            });
        }

        public override void ExitState()
        {
            screen.StartNewGameClicked -= OnStartNewGameClicked;
            screen.ExitMainMenuClicked -= OnExitMainMenuClicked;
            screen.Close();
            screen = null;
        }
    }
}