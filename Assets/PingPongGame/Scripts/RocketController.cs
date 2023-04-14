using System;
using UnityEngine;

namespace PingPongGame.Scripts
{
    public class RocketController : MonoBehaviour
    {
        private bool IsMoving;
        private float targetPosition;
        private float currentPosition;
        public float Speed;

        [SerializeField] private Transform leftWall;
        [SerializeField] private Transform rightWall;
        private Camera camera;
        private float rightThreshold;
        private float leftThreshold;

        public float RelativeSpeed => Math.Abs(delta / Time.deltaTime);
        private float delta;
    
        private void Start()
        {
            camera = Camera.main;
            var length = transform.localScale.x / 2;
            rightThreshold = rightWall.position.x - length;
            leftThreshold = leftWall.position.x + length;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsMoving = true;
            }
        
            if (Input.GetMouseButtonUp(0))
            {
                IsMoving = false;
                delta = 0;
            }

            if (Input.GetMouseButton(0))
            {
                var mousePosition = ResolveMousePosition();
                targetPosition = mousePosition;
            }

            if (IsMoving)
            {
                delta = Math.Min(targetPosition - transform.position.x, Time.deltaTime * Speed);
                transform.Translate(delta, 0, 0);
            }
        }

        private float ResolveMousePosition()
        {
            var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition).x;
            if (mousePosition < leftThreshold)
            {
                mousePosition = leftThreshold;
            }

            if (mousePosition > rightThreshold)
            {
                mousePosition = rightThreshold;
            }

            return mousePosition;
        }
    }
}
