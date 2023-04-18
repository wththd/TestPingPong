using PingPongGame.Scripts.Infrastructure.Entities;
using UnityEngine;

namespace PingPongGame.Scripts.Data
{
    [CreateAssetMenu]
    public class GameModePrefabsContainer : ScriptableObject
    {
        public Ball BallPrefab;
        public Board BoardPrefab;
        public PlayerRocket PlayerRocketPrefab;
        public AIRocket AIRocketPrefab;
    }
}