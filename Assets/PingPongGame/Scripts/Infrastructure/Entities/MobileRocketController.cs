using UnityEngine;

namespace PingPongGame.Scripts
{
    public class MobileRocketController : IRocketController
    {
        public bool ShouldMove => Input.touchCount > 0;
        public Vector2 CurrentPosition => Input.touches[0].position;
    }
}