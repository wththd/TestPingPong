using System.Collections.Generic;
using System.Linq;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateIntents;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Infrastructure.States.MenuStates
{
    public class CustomizeBallState : State<CustomizeBallStateIntent>
    {
        private IUIFactory uiFactory;
        private MenuStateMachine menuStateMachine;
        private IGameStateSaver gameStateSaver;
        private GeneralConfig generalConfig;

        private CustomizeBallScreen screen;
        private bool shouldSave;
        
        public CustomizeBallState(MenuStateMachine menuStateMachine, MenuStatesProvider stateProvider, IUIFactory uiFactory, IGameStateSaver gameStateSaver, GeneralConfig generalConfig)
        {
            stateProvider.RegisterState(this);
            
            this.menuStateMachine = menuStateMachine;
            this.uiFactory = uiFactory;
            this.gameStateSaver = gameStateSaver;
            this.generalConfig = generalConfig;
        }
        
        public override void EnterState()
        {
            screen = uiFactory.CreateCustomizeBallScreen();
            var config = gameStateSaver.CurrentConfig;
            screen.Populate(GenerateCurrentColors(config), config.BallConfig);
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

        private Dictionary<BallConfig, bool> GenerateCurrentColors(GameConfig config)
        {
            var dictionary = new Dictionary<BallConfig, bool> { { generalConfig.DefaultBallConfig, true } };
            foreach (var levelConfig in config.CurrentPlayerSingleProgress.levelConfigs)
            {
                dictionary.Add(levelConfig.reward, config.Rewards.Contains(levelConfig.reward));
            }
            
            foreach (var levelConfig in config.CurrentPlayerMultiplayerProgress.levelConfigs)
            {
                dictionary.Add(levelConfig.reward, config.Rewards.Contains(levelConfig.reward));
            }

            return dictionary;
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