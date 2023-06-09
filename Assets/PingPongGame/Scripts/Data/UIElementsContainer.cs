﻿using PingPongGame.Scripts.Infrastructure.UIElements;
using UnityEngine;

namespace PingPongGame.Scripts.Data
{
    [CreateAssetMenu]
    public class UIElementsContainer : ScriptableObject
    {
        public MainMenu MainMenuPrefab;
        public CustomizeBallScreen CustomizeBallScreen;
        public GameModeScreen GameModeScreen;
        public GamePauseScreen GamePauseScreen;
        public GameCountdownScreen GameCountdownScreen;
        public GamePlayingScreen GamePlayingScreen;
        public GameEndScreen GameEndScreen;
    }
}