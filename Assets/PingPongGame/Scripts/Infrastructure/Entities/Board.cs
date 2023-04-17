using PingPongGame.Scripts.Infrastructure.Entities;
using PingPongGame.Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts
{
    public class Board : MonoBehaviour
    {
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
        }

    }
}