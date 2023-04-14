using System;
using System.Collections.Generic;

namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public class StateProvider : IStateProvider
    {
        private readonly Dictionary<Type, StateWithoutIntent> currentStates = new();
        
        public TState GetState<TState>() where TState : StateWithoutIntent
        {
            return currentStates[typeof(TState)] as TState;
        }

        public void RegisterState<TState> (TState state) where TState : StateWithoutIntent
        {
            currentStates.Add(typeof(TState), state);
        }
    }
}