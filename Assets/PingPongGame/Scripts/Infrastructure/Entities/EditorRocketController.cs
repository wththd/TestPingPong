using UnityEngine;
using UnityEngine.EventSystems;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    public class EditorRocketController : IRocketController
    {
        public bool ShouldMove => Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject();
        public Vector2 CurrentPosition => Input.mousePosition;
    }
}