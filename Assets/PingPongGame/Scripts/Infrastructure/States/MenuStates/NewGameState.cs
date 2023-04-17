using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateIntents;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States.MenuStates;
using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Infrastructure.States
{
    public class NewGameState : State<EmptyStateIntent>
    {
        private GameStateMachine gameStateMachine;
        private IUIFactory uiFactory;
        private MenuStateMachine menuStateMachine;
        private GameModeScreen screen;
        
        public NewGameState(MenuStatesProvider stateProvider, GameStateMachine gameStateMachine, IUIFactory uiFactory, MenuStateMachine menuStateMachine)
        {
            stateProvider.RegisterState(this);

            this.uiFactory = uiFactory;
            this.gameStateMachine = gameStateMachine;
            this.menuStateMachine = menuStateMachine;
        }
        
        public override void EnterState()
        {
            screen = uiFactory.CreateGameModeScreen();
            screen.GameModeChosen += OnGameStateChosen;
            screen.Closed += OnScreenClosed;
        }

        private void OnGameStateChosen(GameModeScreen.GameMode mode)
        {
            switch (mode)
            {
                case GameModeScreen.GameMode.Single:
                    gameStateMachine.SetState<MainMenuState>();
                    gameStateMachine.SetState<GameState, GameStateIntent>(new GameStateIntent
                    {
                        GameMode = mode
                    });
                    return;
                case GameModeScreen.GameMode.AI:
                    gameStateMachine.SetState<GameState, GameStateIntent>(new GameStateIntent
                    {
                        GameMode = mode
                    });
                    return;
            }
            
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