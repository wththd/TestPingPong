using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States.ProjectStates;

namespace PingPongGame.Scripts.Infrastructure.States.MenuStates
{
    public class ContinueGameState : State<EmptyStateIntent>
    {
        private GameStateMachine gameStateMachine;
        public ContinueGameState(MenuStatesProvider stateProvider, GameStateMachine gameStateMachine)
        {
            stateProvider.RegisterState(this);

            this.gameStateMachine = gameStateMachine;
        }
        public override void EnterState()
        {
            gameStateMachine.SetState<GameState>();
        }

        public override void ExitState()
        {
        }
    }
}