using System.Collections.Generic;

namespace PingPongGame.Scripts.Infrastructure.PauseSystem
{
    public class PauseHandler : IPauseHandler
    {
        public bool IsPaused => isPaused;
        
        private List<IPausable> pausables = new();
        private bool isPaused;

        public PauseHandler()
        {
            isPaused = true;
        }
        
        public void Pause()
        {
            foreach (var pausable in pausables)
            {
                pausable.OnPause();
            }

            isPaused = true;
        }

        public void Resume()
        {
            foreach (var pausable in pausables)
            {
                pausable.OnResume();
            }

            isPaused = false;
        }

        public bool RegisterPausable(IPausable pausable)
        {
            pausables.Add(pausable);
            return IsPaused;
        }

        public void UnregisterPausable(IPausable pausable)
        {
            pausables.Remove(pausable);
        }
    }
}