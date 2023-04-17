using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : StateMachine<GameStatesProvider>, IInitializable
    { 
        protected GameStateMachine(GameStatesProvider stateProvider) : base(stateProvider)
        {
        }

        public void Initialize()
        {
            Debug.Log($"Init {nameof(GameStateMachine)}");
            SetState<BootstrapState>();
        }
    }
}