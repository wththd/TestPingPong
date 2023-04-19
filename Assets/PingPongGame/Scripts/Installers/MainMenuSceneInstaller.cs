using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Entities;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    public class MainMenuSceneInstaller : MonoInstaller
    {
        [SerializeField] 
        private Transform sceneCanvas;
        [SerializeField] 
        private ColorTemplate colorTemplatePrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().WithArguments(sceneCanvas);

            MenuStateMachineInstaller.Install(Container);

            BindFactories();
        }

        private void BindFactories()
        {
            Container.BindFactory<BallConfig, bool, Transform, ColorTemplate, ColorTemplateFactory>()
                .FromComponentInNewPrefab(colorTemplatePrefab);
        }
    }
}