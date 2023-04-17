using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour, IPausable
    {
        private Rigidbody rb;

        private Vector3 startDirection;
        private float targetSpeed;
        private float smoothingFactor;
        public float hitForce;

        private bool isPaused;
        private Vector3 pausedSpeed;

        [Inject]
        private void Init(BallFactory.Settings settings, Transform rootTransform, IPauseHandler pauseHandler)
        {
            isPaused = pauseHandler.RegisterPausable(this);
            
            startDirection = settings.Direction;
            targetSpeed = settings.TargetSpeed;
            smoothingFactor = settings.SmoothingFactor;
            hitForce = settings.HitForce;
            transform.SetParent(rootTransform, false);
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            pausedSpeed = startDirection * targetSpeed;
        }

        private void LateUpdate()
        {
            if (isPaused)
            {
                rb.velocity = Vector3.zero;
                return;
            }
            
            var currentVelocity = rb.velocity;
            var targetVelocity = currentVelocity.normalized * targetSpeed;
            rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime * smoothingFactor);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Rocket"))
            {
                var rocketSpeed = other.gameObject.GetComponent<Rocket>().RelativeSpeed;
                if (rocketSpeed > 1)
                {
                    rb.AddForce(hitForce * rocketSpeed * other.GetContact(0).normal, ForceMode.Impulse);
                }
            }
        }

        public void OnPause()
        {
            isPaused = true;
            pausedSpeed = rb.velocity;
        }

        public void OnResume()
        {
            rb.velocity = pausedSpeed;
            isPaused = false;
        }
    }
}