using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : StateMachine, IInitializable
    {
        public StateWithoutIntent CurrentState;

        private IStateProvider stateProvider;

        protected GameStateMachine(GameStatesProvider stateProvider)
        {
            this.stateProvider = stateProvider;
        }

        public override void SetState<TState, TStateIntent>(TStateIntent intent = default(TStateIntent))
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
    
        public override void SetState<TState>()
        {
            CurrentState?.ExitState();

            var state = stateProvider.GetState<TState>();
            CurrentState = state;
            CurrentState.EnterState();
        }

        public void Initialize()
        {
            Debug.Log("Init");
        }
    }
}