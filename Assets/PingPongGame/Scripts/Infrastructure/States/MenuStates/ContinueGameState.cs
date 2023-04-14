using PingPongGame.Scripts.Infrastructure.StateMachine;

namespace PingPongGame.Scripts.Infrastructure.States
{
    public class ContinueGameState : State<EmptyStateIntent>
    {
        public ContinueGameState(MenuStatesProvider stateProvider)
        {
            stateProvider.RegisterState(this);
        }
        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}