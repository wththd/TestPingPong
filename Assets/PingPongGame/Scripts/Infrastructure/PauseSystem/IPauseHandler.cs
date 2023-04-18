namespace PingPongGame.Scripts.Infrastructure.PauseSystem
{
    public interface IPauseHandler
    {
        void Pause();
        void Resume();
        bool RegisterPausable(IPausable pausable);
        void UnregisterPausable(IPausable pausable);
        public bool IsPaused { get; }
    }
}