using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateMachine;

namespace PingPongGame.Scripts.Infrastructure.States
{
    public class NewGameState : State<EmptyStateIntent>
    {
        private GameStateMachine gameStateMachine;
        private IUIFactory uiFactory;
        
        public NewGameState(MenuStatesProvider stateProvider, GameStateMachine gameStateMachine, IUIFactory uiFactory)
        {
            stateProvider.RegisterState(this);

            this.uiFactory = uiFactory;
        }
        
        public override void EnterState()
        {
            uiFactory.CreateGameModeScreen();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}