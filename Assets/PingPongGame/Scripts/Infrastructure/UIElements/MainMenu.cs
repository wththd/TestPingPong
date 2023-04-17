using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateIntents;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States;
using PingPongGame.Scripts.Infrastructure.States.MenuStates;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.UIElements
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] 
        private Button continueButton;
        
        private MenuStateMachine menuStateMachine;
        private GameConfig gameConfig;
        
        [Inject]
        private void Init(MenuStateMachine menuStateMachine, GameConfig gameConfig)
        {
            this.menuStateMachine = menuStateMachine;
            this.gameConfig = gameConfig;

            continueButton.interactable = this.gameConfig.CurrentGameProgress != null;
        }

        public void OnNewGameClick()
        {
            menuStateMachine.SetState<NewGameState>();
        }

        public void OnContinueClick()
        {
            menuStateMachine.SetState<ContinueGameState>();
        }

        public void OnCustomizeClick()
        {
            menuStateMachine?.SetState<CustomizeBallState, CustomizeBallStateIntent>(new CustomizeBallStateIntent{ BallConfig = gameConfig.BallConfig });
        }
    }
}