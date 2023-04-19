using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.UIElements;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.States.GameModeStates
{
    public class GamePlayingState : State<EmptyStateIntent>, ITickable
    {
        private IPauseHandler pauseHandler;
        private IUIFactory uiFactory;
        private GamePlayingScreen screen;
        private GameModeStateMachine gameModeStateMachine;
        private GeneralConfig generalConfig;
        private IGameStateSaver gameStateSaver;
        private float tickTime;
        private SharedGameData sharedGameData;
        
        public GamePlayingState(GameModeStateProvider gameModeStatesProvider, GameModeStateMachine gameModeStateMachine, IPauseHandler pauseHandler, 
            IUIFactory uiFactory, GeneralConfig generalConfig, IGameStateSaver gameStateSaver, SharedGameData sharedGameData)
        {
            gameModeStatesProvider.RegisterState(this);
            
            this.pauseHandler = pauseHandler;
            this.uiFactory = uiFactory;
            this.gameModeStateMachine = gameModeStateMachine;
            this.generalConfig = generalConfig;
            this.gameStateSaver = gameStateSaver;
            this.sharedGameData = sharedGameData;
        }
        
        public override void EnterState()
        {
            sharedGameData.Board.PlayerTriggerFired += BoardOnPlayerTriggerFired;
            sharedGameData.Board.OppositeTriggerFired += BoardOnOppositeTriggerFired;
            sharedGameData.Ball.HitRocket += BallOnHitRocket;
            pauseHandler.Resume();
            if (screen == null)
            {
                screen = uiFactory.CreateGamePlayingScreen();
                screen.MenuButtonClicked += OnMenuButtonClick;
            }
        }

        private void BallOnHitRocket()
        {
            if (gameStateSaver.CurrentConfig.CurrentGameMode == GameModeScreen.GameMode.Single)
            {
                gameStateSaver.AddSingleLevelProgress();
            }
            else
            {
                gameStateSaver.AddMultiplayerLevelProgress();
            }
        }

        private void BoardOnOppositeTriggerFired()
        {
            gameModeStateMachine.SetState<GameEndState>();
        }

        private void BoardOnPlayerTriggerFired()
        {
            gameModeStateMachine.SetState<GameEndState>();
        }

        private void OnMenuButtonClick()
        {
            gameModeStateMachine.SetState<PauseMenuState>();
        }

        public override void ExitState()
        {
            sharedGameData.Board.PlayerTriggerFired -= BoardOnPlayerTriggerFired;
            sharedGameData.Board.OppositeTriggerFired -= BoardOnOppositeTriggerFired;
            sharedGameData.Ball.HitRocket -= BallOnHitRocket;
        }

        public void Tick()
        {
            if (pauseHandler.IsPaused)
            {
                return;
            }
            
            tickTime += Time.deltaTime;
            if (tickTime >= generalConfig.SaveTime)
            {
                tickTime -= generalConfig.SaveTime;
                gameStateSaver.Save();
            }
        }
    }
}