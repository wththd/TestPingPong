using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    public class MainMenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform sceneCanvas;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().WithArguments(sceneCanvas);

            MenuStateMachineInstaller.Install(Container);
        }
    }
}