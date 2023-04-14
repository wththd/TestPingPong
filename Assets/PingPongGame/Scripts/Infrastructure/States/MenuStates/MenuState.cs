using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.UIElements;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.States.MenuStates
{
    public class MenuState : State<EmptyStateIntent>
    {
        private IUIFactory uiFactory;
        private MainMenu screen;
        
        public MenuState(MenuStatesProvider stateProvider, IUIFactory uiFactory)
        {
            stateProvider.RegisterState(this);
            this.uiFactory = uiFactory;
        }
        
        public override void EnterState()
        {
            if (screen == null)
            {
                screen = uiFactory.CreateMainMenuUI();
            }
        }

        public override void ExitState()
        {
            Debug.Log("MenuState exit");
        }
    }
}