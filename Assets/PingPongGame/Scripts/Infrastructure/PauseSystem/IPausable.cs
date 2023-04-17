namespace PingPongGame.Scripts.Infrastructure.PauseSystem
{
    public interface IPausable
    {
        void OnPause();
        void OnResume();
    }
}