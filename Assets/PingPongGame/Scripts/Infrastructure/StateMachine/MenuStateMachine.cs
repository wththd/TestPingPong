using PingPongGame.Scripts.Infrastructure.States.MenuStates;
using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public class MenuStateMachine : StateMachine<MenuStatesProvider>, IInitializable
    {
#if UNITY_EDITOR
        // Field injection just for editor for correct bootstrap
        [Inject]
        private GameStateMachine gameStateMachine;
#endif
        protected MenuStateMachine(MenuStatesProvider stateProvider) : base(stateProvider)
        {
        }

        public void Initialize()
        {
#if UNITY_EDITOR
            if (gameStateMachine.CurrentState is not MainMenuState)
            {
                return;
            }
#endif
            SetState<MenuState>();
        }
    }
}