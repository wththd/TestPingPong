using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace PingPongGame.Scripts.Infrastructure
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void LoadScene(string name, Action onLoad = null)
        {
            _coroutineRunner.RunRoutine(LoadSceneRoutine(name, onLoad));
        }

        private IEnumerator LoadSceneRoutine(string name, Action onFinish = null)
        {
            if (SceneManager.GetActiveScene().name.Equals(name))
            {
                onFinish?.Invoke();
                yield break;
            }
            
            var operation = SceneManager.LoadSceneAsync(name);

            while (!operation.isDone)
            {
                yield return null;
            }
            
            onFinish?.Invoke();
        }
    }
}