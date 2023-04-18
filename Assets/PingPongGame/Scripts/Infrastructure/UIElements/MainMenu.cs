using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateIntents;
using PingPongGame.Scripts.Infrastructure.StateMachine;
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
        private IGameStateSaver gameStateSaver;
        
        [Inject]
        private void Init(MenuStateMachine menuStateMachine, IGameStateSaver gameStateSaver)
        {
            this.menuStateMachine = menuStateMachine;
            this.gameStateSaver = gameStateSaver;

            continueButton.interactable = this.gameStateSaver.CurrentConfig.HasProgress;
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
            menuStateMachine?.SetState<CustomizeBallState, CustomizeBallStateIntent>(new CustomizeBallStateIntent{ BallConfig = gameStateSaver.CurrentConfig.BallConfig });
        }
    }
}