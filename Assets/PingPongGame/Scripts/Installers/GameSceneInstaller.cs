using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Ball ballPrefab;
        [SerializeField] 
        private Transform ballSpawnPoint;
        public override void InstallBindings()
        {
            InstallFactories();
        }

        private void InstallFactories()
        {
            Container.BindFactory<Vector3, Ball, BallFactory>().FromComponentInNewPrefab(ballPrefab)
                .UnderTransform(ballSpawnPoint);
        }
    }
}