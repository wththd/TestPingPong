using System;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.UIElements
{
    public class GamePauseScreen : MonoBehaviour
    {
        public event Action ContinueClicked;
        public event Action ExitClicked;
        
        public void OnContinueClick()
        {
            ContinueClicked?.Invoke();
        }

        public void OnExitClick()
        {
            ExitClicked?.Invoke();
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