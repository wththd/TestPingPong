using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateIntents;
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
        private IGameStateSaver gameStateSaver;
        
        public GameModeStateMachine(GameModeStateProvider stateProvider, IGameStateSaver gameStateSaver) : base(stateProvider)
        {
            this.gameStateSaver = gameStateSaver;
        }
        
        public void Initialize()
        {
#if UNITY_EDITOR
            if (gameStateMachine.CurrentState is not GameState)
            {
                return;
            }
#endif
            SetState<LoadLevelState, LoadLevelStateIntent>(new LoadLevelStateIntent
            {
                GameMode = gameStateSaver.CurrentConfig.CurrentGameMode
            });
        }
    }
}