using System;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.UIElements
{
    public class GamePlayingScreen : MonoBehaviour
    {
        public event Action MenuButtonClicked;

        public void OnMenuButtonClick()
        {
            MenuButtonClicked?.Invoke();
        }
    }
}