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
    public class AIRocket : Rocket
    {
        private AIRocketController rocketController;
        private SharedGameData sharedGameData;
        private float speed;
        
        private float targetPosition;

        
        [Inject]
        private void Init(AIRocketController aiRocketController, SharedGameData sharedGameData, AIRocketFactory.Settings settings, IPauseHandler pauseHandler, IGameStateSaver gameStateSaver)
        {
            this.pauseHandler = pauseHandler;
            this.gameStateSaver = gameStateSaver;
            
            gameStateSaver.RegisterSavable(this);
            pauseHandler.RegisterPausable(this);
            
            rocketController = aiRocketController;
            rocketController.Position = transform;
            rocketController.MoveDifference = settings.MoveReaction;
            this.sharedGameData = sharedGameData;
            rocketController.Target = sharedGameData.Ball.transform;
            speed = settings.Speed;
            leftWallPosition = settings.WallPositions.x;
            rightWallPosition = settings.WallPositions.y;
        }
        private void Update()
        {
            if (IsPaused)
            {
                return;
            }
            
            if (rocketController.ShouldMove)
            {
                CalculateTargetPosition();
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
        
        private void CalculateTargetPosition()
        {
            targetPosition = rocketController.Target.position.x;
            if (targetPosition < rightThreshold)
            {
                targetPosition = rightThreshold;
            }

            if (targetPosition > leftThreshold)
            {
                targetPosition = leftThreshold;
            }
        }

        public override void Save(GameConfig gameConfig)
        {
            gameConfig.CurrentGameProgress.OppositeRocketData = rocketData;
        }
    }
}