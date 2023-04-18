using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Entities;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private GameModePrefabsContainer prefabsContainer;
        [SerializeField] 
        private Transform uiRoot;
        [SerializeField] 
        private Transform boardRoot;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().WithArguments(uiRoot);
            Container.Bind<IPauseHandler>().To<PauseHandler>().AsSingle();
#if UNITY_EDITOR
            Container.Bind<IRocketController>().To<EditorRocketController>().AsSingle();
#else
            Container.Bind<IRocketController>().To<MobileRocketController>().AsSingle();
#endif
            Container.Bind<AIRocketController>().AsSingle();
            Container.Bind<SharedGameData>().AsSingle();
            GameModeStateMachineInstaller.Install(Container);

            InstallFactories();
        }

        private void InstallFactories()
        {
            Container.BindFactory<BallFactory.Settings, Transform, Ball, BallFactory>().FromComponentInNewPrefab(prefabsContainer.BallPrefab);
            Container.BindFactory<PlayerRocketFactory.Settings, PlayerRocket, PlayerRocketFactory>().FromComponentInNewPrefab(prefabsContainer.PlayerRocketPrefab);
            Container.BindFactory<BoardFactory.Settings, Board, BoardFactory>().FromComponentInNewPrefab(prefabsContainer.BoardPrefab).UnderTransform(boardRoot);
            Container.BindFactory<AIRocketFactory.Settings, AIRocket, AIRocketFactory>().FromComponentInNewPrefab(prefabsContainer.AIRocketPrefab);
        }
    }
}