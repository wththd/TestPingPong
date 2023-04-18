using System;
using PingPongGame.Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    public class Board : MonoBehaviour
    {
        public event Action OppositeTriggerFired;
        public event Action PlayerTriggerFired;
        public Transform PlayerRocketSpawnPosition;
        public Transform OppositeRocketSpawnPosition;
        public Transform LeftWallTransform;
        public Transform RightWallTransform;
        public Transform BallSpawnPosition;
        
        [SerializeField]
        private Transform plane;
        [SerializeField] 
        private LooseTrigger oppositeLooseTrigger;
        [SerializeField] 
        private LooseTrigger playerLooseTrigger;

        [Inject]
        private void Init(BoardFactory.Settings settings)
        {
            plane.transform.localScale = new Vector3(settings.PlaneScale.X, 1, settings.PlaneScale.Y);
            oppositeLooseTrigger.OnBallReached += OppositeTriggerOnBallReached;
            playerLooseTrigger.OnBallReached += PlayerTriggerOnBallReached;
        }

        private void OppositeTriggerOnBallReached()
        {
            OppositeTriggerFired?.Invoke();
        }
        
        private void PlayerTriggerOnBallReached()
        {
            PlayerTriggerFired?.Invoke();
        }

        private void OnDestroy()
        {
            oppositeLooseTrigger.OnBallReached -= OppositeTriggerOnBallReached;
            playerLooseTrigger.OnBallReached -= PlayerTriggerOnBallReached;
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}