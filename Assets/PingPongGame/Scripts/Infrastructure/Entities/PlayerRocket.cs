using System;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    public class PlayerRocket : Rocket
    {
        private float targetPosition;
        private float speed;
        private Camera gameCamera;
        private IRocketController rocketController;
        private bool isPlayerRocket;

        [Inject]
        private void Init(PlayerRocketFactory.Settings settings, IRocketController rocketController, IPauseHandler pauseHandler, IGameStateSaver gameStateSaver)
        {
            IsPaused = pauseHandler.RegisterPausable(this);
            gameStateSaver.RegisterSavable(this);

            leftWallPosition = settings.WallPositions.x;
            rightWallPosition = settings.WallPositions.y;
            speed = settings.Speed;
            isPlayerRocket = settings.IsPlayer;
            
            this.rocketController = rocketController;
            this.pauseHandler = pauseHandler;
            this.gameStateSaver = gameStateSaver;
        }
        
        protected override void Start()
        {
            base.Start();
            gameCamera = Camera.main;
        }

        private void Update()
        {
            if (rocketController.ShouldMove && !IsPaused)
            {
                targetPosition = ResolvePointerPosition(rocketController.CurrentPosition);
                var positionDelta = targetPosition - transform.position.x;
                var currentSpeed = Time.deltaTime * speed;
                if (Math.Abs(positionDelta) > currentSpeed)
                {
                    positionDelta = positionDelta > 0 ? currentSpeed : -currentSpeed;
                }
                Delta = positionDelta;
                transform.Translate(Delta, 0, 0);
            }

            rocketData.Position = transform.localPosition.ToNumeric();
        }

        private float ResolvePointerPosition(Vector2 pointerPosition)
        {
            var position = gameCamera.ScreenToWorldPoint(pointerPosition).x;
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

        public override void Save(GameConfig gameConfig)
        {
            if (isPlayerRocket)
            {
                gameConfig.CurrentGameProgress.PlayerRocketData = rocketData;
            }
            else
            {
                gameConfig.CurrentGameProgress.OppositeRocketData = rocketData;
            }
        }
    }
}