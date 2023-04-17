using PingPongGame.Scripts.Infrastructure.States.GameModeStates;
using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public class GameModeStateMachine : StateMachine<GameModeStateProvider>, IInitializable
    {
#if UNITY_EDITOR
        // Field injection just for editor for correct bootstrap
        [Inject]
        private GameStateMachine gameStateMachine;
#endif
        public GameModeStateMachine(GameModeStateProvider stateProvider) : base(stateProvider)
        {
        }
        
        public void Initialize()
        {
#if UNITY_EDITOR
            if (gameStateMachine.CurrentState is not GameState)
            {
                return;
            }
#endif
            Debug.Log($"Init {nameof(GameModeStateMachine)}");
            SetState<LoadLevelState>();
        }
    }
}