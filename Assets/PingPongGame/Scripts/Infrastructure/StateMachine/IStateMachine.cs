namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public interface IStateMachine
    {
        void SetState<TState, TStateIntent>(TStateIntent intent = default(TStateIntent))
            where TState : State<TStateIntent>;

        void SetState<TState>() where TState : StateWithoutIntent;
    }
}