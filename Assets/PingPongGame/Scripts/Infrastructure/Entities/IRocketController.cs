using UnityEngine;

namespace PingPongGame.Scripts
{
    public interface IRocketController
    {
        bool ShouldMove { get; }
        Vector2 CurrentPosition { get; }
    }
}