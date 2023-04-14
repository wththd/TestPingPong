namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public interface IState
    {
        public void EnterState();
        public void ExitState();
    }
}
