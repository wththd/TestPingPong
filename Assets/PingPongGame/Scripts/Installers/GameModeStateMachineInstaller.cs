using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.States.GameModeStates;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    public class GameModeStateMachineInstaller : Installer<GameModeStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameModeStateProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameModeStateMachine>().AsSingle();
            Container.Bind<CountdownState>().AsSingle().NonLazy();
            Container.Bind<LoadLevelState>().AsSingle().NonLazy();
            Container.Bind<PauseMenuState>().AsSingle().NonLazy();
            Container.Bind<GamePlayingState>().AsSingle().NonLazy();
        }
    }
}