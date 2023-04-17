using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.UIElements;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private UIElementsContainer elementsContainer;
        private DiContainer container;
        private IInstantiator instantiator;
        private Transform parentTransform;
        
        public UIFactory(UIElementsContainer elementsContainer, IInstantiator instantiator, Transform parentTransform)
        {
            this.elementsContainer = elementsContainer;
            this.instantiator = instantiator;
            this.parentTransform = parentTransform;
        }

        public MainMenu CreateMainMenuUI()
        {
            var mainMenu = instantiator.InstantiatePrefabForComponent<MainMenu>(elementsContainer.MainMenuPrefab, parentTransform);
            return mainMenu;
        }

        public CustomizeBallScreen CreateCustomizeBallScreen()
        {
            var customizeBallScreen = instantiator.InstantiatePrefabForComponent<CustomizeBallScreen>(elementsContainer.CustomizeBallScreen, parentTransform);
            return customizeBallScreen;
        }

        public GameModeScreen CreateGameModeScreen()
        {
            var gameMode = instantiator.InstantiatePrefabForComponent<GameModeScreen>(elementsContainer.GameModeScreen, parentTransform);
            return gameMode;
        }

        public GamePauseScreen CreateGamePauseScreen()
        {
            var gamePauseScreen = instantiator.InstantiatePrefabForComponent<GamePauseScreen>(elementsContainer.GamePauseScreen, parentTransform);
            return gamePauseScreen;
        }
        
        public GameCountdownScreen CreateGameCountdownScreen()
        {
            var gameCountdown = instantiator.InstantiatePrefabForComponent<GameCountdownScreen>(elementsContainer.GameCountdownScreen, parentTransform);
            return gameCountdown;
        }
        
        public GamePlayingScreen CreateGamePlayingScreen()
        {
            var gameCountdown = instantiator.InstantiatePrefabForComponent<GamePlayingScreen>(elementsContainer.GamePlayingScreen, parentTransform);
            return gameCountdown;
        }
    }
}