using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPongGame.Scripts
{
    public interface ICoroutineRunner
    {
        Coroutine RunRoutine(IEnumerator coroutine);
    }
}