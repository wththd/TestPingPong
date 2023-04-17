
using UnityEngine;

namespace PingPongGame.Scripts
{
    public class AIRockerController : IRocketController
    {
        public bool ShouldMove => false;
        public Vector2 CurrentPosition { get; }
    }
}