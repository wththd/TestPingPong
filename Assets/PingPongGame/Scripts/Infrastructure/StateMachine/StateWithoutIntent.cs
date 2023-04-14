namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public abstract class StateWithoutIntent : IState
    {
        public abstract void EnterState();

        public abstract void ExitState();
    }
}