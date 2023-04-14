using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateIntents;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.UIElements;
using PingPongGame.Scripts.SaveSystem;

namespace PingPongGame.Scripts.Infrastructure.States.MenuStates
{
    public class CustomizeBallState : State<CustomizeBallStateIntent>
    {
        private IUIFactory uiFactory;
        private MenuStateMachine menuStateMachine;
        private IGameStateSaver gameStateSaver;

        private CustomizeBallScreen screen;
        private bool shouldSave;
        
        public CustomizeBallState(MenuStateMachine menuStateMachine, MenuStatesProvider stateProvider, IUIFactory uiFactory, IGameStateSaver gameStateSaver)
        {
            stateProvider.RegisterState(this);
            
            this.menuStateMachine = menuStateMachine;
            this.uiFactory = uiFactory;
            this.gameStateSaver = gameStateSaver;
        }
        
        public override void EnterState()
        {
            screen = uiFactory.CreateCustomizeBallScreen();
            screen.Closed += OnScreenClosed;
            screen.Applied += OnConfigsApplied;
        }

        private void OnConfigsApplied()
        {
            screen.Applied -= OnConfigsApplied;
            shouldSave = true;
            menuStateMachine.SetState<MenuState>();
        }

        private void OnScreenClosed()
        {
            screen.Closed -= OnScreenClosed;
            menuStateMachine.SetState<MenuState>();
        }

        public override void ExitState()
        {
            if (shouldSave)
            {
                gameStateSaver.SaveBallConfig(screen.BallConfig);
            }

            screen.Close();
        }
    }
}