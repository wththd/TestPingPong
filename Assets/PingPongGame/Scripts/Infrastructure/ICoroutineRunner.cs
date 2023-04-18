using System.Collections;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine RunRoutine(IEnumerator coroutine);
    }
}