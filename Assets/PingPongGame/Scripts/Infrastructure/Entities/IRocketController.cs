using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    public interface IRocketController
    {
        bool ShouldMove { get; }
        Vector2 CurrentPosition { get; }
    }
}