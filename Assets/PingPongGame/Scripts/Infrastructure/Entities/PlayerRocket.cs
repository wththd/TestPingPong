using System;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts
{
    public class PlayerRocket : Rocket
    {
        private float targetPosition;
        private float currentPosition;
        public float Speed;
        private Camera camera;
        private float rightThreshold;
        private float leftThreshold;
        private float leftWallPosition;
        private float rightWallPosition;
        private IRocketController rocketController;

        [Inject]
        private void Init(PlayerRocketFactory.Settings settings, IRocketController rocketController, IPauseHandler pauseHandler)
        {
            IsPaused = pauseHandler.RegisterPausable(this);
            
            leftWallPosition = settings.WallPositions.x;
            rightWallPosition = settings.WallPositions.y;
            Speed = settings.Speed;
            
            this.rocketController = rocketController;
        }
        
        private void Start()
        {
            camera = Camera.main;
            var length = transform.localScale.x / 2;
            rightThreshold = rightWallPosition + length;
            leftThreshold = leftWallPosition - length;
        }

        private void Update()
        {
            if (rocketController.ShouldMove && !IsPaused)
            {
                targetPosition = ResolvePointerPosition(rocketController.CurrentPosition);
                var positionDelta = targetPosition - transform.position.x;
                var speed = Time.deltaTime * Speed;
                if (Math.Abs(positionDelta) > speed)
                {
                    positionDelta = positionDelta > 0 ? speed : -speed;
                }
                Delta = positionDelta;
                transform.Translate(Delta, 0, 0);
            }
        }

        private float ResolvePointerPosition(Vector2 pointerPosition)
        {
            var position = camera.ScreenToWorldPoint(pointerPosition).x;
            if (position < rightThreshold)
            {
                position = rightThreshold;
            }

            if (position > leftThreshold)
            {
                position = leftThreshold;
            }

            return position;
        }
    }
}