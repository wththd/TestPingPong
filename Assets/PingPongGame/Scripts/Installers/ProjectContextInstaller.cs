using System.Collections;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.SaveSystem;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    public class ProjectContextInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(this);
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IGameStateSaver>().To<GameStateSaver>().AsSingle();
            Container.Bind<GameStatesProvider>().AsSingle();
            Container.Bind<GameConfig>().AsSingle().NonLazy();

            GameStateMachineInstaller.Install(Container);
        }

        public Coroutine RunRoutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}
