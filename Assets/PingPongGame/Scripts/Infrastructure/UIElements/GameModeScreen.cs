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
        public event Action Closed;

        public void OnSinglePlayerClick()
        {
            GameModeChosen?.Invoke(GameMode.Single);
        }

        public void OnMultiplayerClick()
        {
            GameModeChosen?.Invoke(GameMode.AI);
        }

        public void OnCloseClick()
        {
            Closed?.Invoke();
        }

        public void Close()
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}