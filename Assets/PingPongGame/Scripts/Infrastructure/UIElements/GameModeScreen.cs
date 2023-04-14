using System;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.UIElements
{
    public class GameModeScreen : MonoBehaviour
    {
        public enum GameMode
        {
            None,
            Single,
            AI
        }

        public event Action<GameMode> GameModeChosen;
    }
}