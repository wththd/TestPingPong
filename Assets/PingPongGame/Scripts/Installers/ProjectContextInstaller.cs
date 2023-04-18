using System;
using System.Collections;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateMachine;
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
            Container.Bind(typeof(IGameStateSaver), typeof(IDisposable)).To<GameStateSaver>().AsSingle();
            Container.Bind<IDataSaver<GameConfig>>().To<PlayerPrefsDataSaver>().AsSingle();

            GameStateMachineInstaller.Install(Container);
        }

        public Coroutine RunRoutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}
