using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Infrastructure.States.GameModeStates
{
    public class CountdownState : State<EmptyStateIntent>
    {
        private IUIFactory uiFactory;
        private GameModeStateMachine gameModeStateMachine;
        private GameCountdownScreen screen;
        
        public CountdownState(GameModeStateProvider gameModeStatesProvider, IUIFactory uiFactory, GameModeStateMachine gameModeStateMachine)
        {
            gameModeStatesProvider.RegisterState(this);

            this.uiFactory = uiFactory;
            this.gameModeStateMachine = gameModeStateMachine;
        }
        
        public override void EnterState()
        {
            screen = uiFactory.CreateGameCountdownScreen();
            screen.StartCountDown(1);
            screen.CountdownFinished += OnCountdownFinished;
        }

        private void OnCountdownFinished()
        {
            screen.CountdownFinished -= OnCountdownFinished;
            screen.Close();
            gameModeStateMachine.SetState<GamePlayingState>();
        }

        public override void ExitState()
        {
        }
    }
}