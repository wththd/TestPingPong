using System;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using UnityEngine;

namespace PingPongGame.Scripts
{
    public class Rocket : MonoBehaviour, IPausable
    {
        public float RelativeSpeed => Math.Abs(Delta / Time.deltaTime);
        protected float Delta;
        protected bool IsPaused;
        
        public void OnPause()
        {
            IsPaused = true;
        }

        public void OnResume()
        {
            IsPaused = false;
        }
    }
}