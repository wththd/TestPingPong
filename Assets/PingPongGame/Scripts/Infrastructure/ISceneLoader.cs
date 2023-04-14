using System;

namespace PingPongGame.Scripts.Infrastructure
{
    public interface ISceneLoader
    {
        void LoadScene(string name, Action onLoad = null);
    }
}