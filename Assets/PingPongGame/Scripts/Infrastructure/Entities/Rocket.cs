using System;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    public class Rocket : MonoBehaviour, IPausable, ISavable
    {
        public float RelativeSpeed => Math.Abs(Delta / Time.deltaTime);
        protected float Delta;
        protected bool IsPaused;
        protected IPauseHandler pauseHandler;
        protected IGameStateSaver gameStateSaver;
        protected RocketData rocketData = new();
        protected float rightThreshold;
        protected float leftThreshold;
        protected float leftWallPosition;
        protected float rightWallPosition;

        protected virtual void Start()
        {
            var length = transform.lossyScale.x / 2;
            // We assume that walls are 0.2 width always
            rightThreshold = rightWallPosition + length + 0.1f;
            leftThreshold = leftWallPosition - length - 0.1f;
        }
        
        private void OnDestroy()
        {
            pauseHandler?.UnregisterPausable(this);
            gameStateSaver?.UnregisterSavable(this);
        }
        
        public void OnPause()
        {
            IsPaused = true;
        }

        public void OnResume()
        {
            IsPaused = false;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        public virtual void Save(GameConfig gameConfig)
        {
        }
    }
}