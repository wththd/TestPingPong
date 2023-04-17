using System;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    public class LooseTrigger : MonoBehaviour
    {
        public event Action OnBallReached;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                Destroy(other.gameObject);
                OnBallReached?.Invoke();
            }
        }
    }
}
