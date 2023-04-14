using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        private Vector3 startDirection;
        public float TargetSpeed;
        private Rigidbody rb;
        private float time;
        public float SmoothingFactor;
        private bool rocketHit;
        public float HitForce;

        [Inject]
        private void Init(Vector3 startDirection)
        {
            this.startDirection = startDirection;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = startDirection * TargetSpeed;
        }

        private void LateUpdate()
        {
            var currentVelocity = rb.velocity;
            var targetVelocity = currentVelocity.normalized * TargetSpeed;
            rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime * SmoothingFactor);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Rocket"))
            {
                var rocketSpeed = other.gameObject.GetComponent<RocketController>().RelativeSpeed;
                Debug.Log("rocket speed " + rocketSpeed);
                if (rocketSpeed > 1)
                {
                    rb.AddForce(HitForce * rocketSpeed * other.GetContact(0).normal, ForceMode.Impulse);
                }
            }
        }
    }
}