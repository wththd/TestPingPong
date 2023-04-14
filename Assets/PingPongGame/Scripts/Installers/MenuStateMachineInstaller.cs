using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States;
using PingPongGame.Scripts.Infrastructure.States.MenuStates;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    public class MenuStateMachineInstaller : Installer<MenuStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuStateMachine>().AsSingle().NonLazy();
            Container.Bind<MenuState>().AsSingle().NonLazy();
            Container.Bind<CustomizeBallState>().AsSingle().NonLazy();
            Container.Bind<ContinueGameState>().AsSingle().NonLazy();
            Container.Bind<NewGameState>().AsSingle().NonLazy();
        }
    }
}