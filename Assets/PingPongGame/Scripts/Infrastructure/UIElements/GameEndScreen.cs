using System;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.UIElements
{
    public class GameEndScreen : MonoBehaviour
    {
        public event Action StartNewGameClicked;
        public event Action ExitMainMenuClicked;

        public void OnStartNewGameClick()
        {
            StartNewGameClicked?.Invoke();
        }

        public void OnExitMainMenuClick()
        {
            ExitMainMenuClicked?.Invoke();
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