using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States.ProjectStates;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStatesProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle().NonLazy();
            Container.Bind<MainMenuState>().AsSingle().NonLazy();
            Container.Bind<GameState>().AsSingle().NonLazy();
        }
    }
}