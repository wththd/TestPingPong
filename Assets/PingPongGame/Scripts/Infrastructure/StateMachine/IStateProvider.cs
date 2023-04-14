namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public interface IStateProvider
    {
        TState GetState<TState>() where TState : StateWithoutIntent;
        void RegisterState<TState>(TState state) where TState : StateWithoutIntent;
    }
}