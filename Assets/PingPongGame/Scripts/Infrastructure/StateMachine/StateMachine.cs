namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public abstract class StateMachine : IStateMachine
    {
        public abstract void SetState<TState, TStateIntent>(TStateIntent intent = default(TStateIntent))
            where TState : State<TStateIntent>;

        public abstract void SetState<TState>() where TState : StateWithoutIntent;
    }
}