using System;
using PingPongGame.Scripts.Data;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.UIElements
{
    public class CustomizeBallScreen : MonoBehaviour
    {
        public event Action Closed;
        public event Action Applied;

        public BallConfig BallConfig => ballConfig;
        private BallConfig ballConfig;

        public void Populate(BallConfig ballConfig)
        {
            this.ballConfig = ballConfig;
        }

        public void OnCloseClick()
        {
            Closed?.Invoke();
        }

        public void OnApplyClick()
        {
            Applied?.Invoke();
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}