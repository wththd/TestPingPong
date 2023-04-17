namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public abstract class StateMachine<T> : IStateMachine where T : IStateProvider
    {
        public StateWithoutIntent CurrentState;

        private T stateProvider;

        public StateMachine(T stateProvider)
        {
            this.stateProvider = stateProvider;
        }
        
        public virtual void SetState<TState, TStateIntent>(TStateIntent intent = default) where TState : State<TStateIntent>
        {
            if (CurrentState != null)
            {
                CurrentState.ExitState();
            }

            var state = (State<TStateIntent>)stateProvider.GetState<TState>();
            state.SetIntent(intent);
            CurrentState = state;
            CurrentState.EnterState();
        }
    
        public virtual void SetState<TState>() where TState : StateWithoutIntent
        {
            CurrentState?.ExitState();

            var state = stateProvider.GetState<TState>();
            CurrentState = state;
            CurrentState.EnterState();
        }
    }
}