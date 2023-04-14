using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts
{
    public class Restart : MonoBehaviour
    {
        private BallFactory ballFactory;
    
        [Inject]
        private void Init(BallFactory ballFactory)
        {
            this.ballFactory = ballFactory;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                Destroy(other.gameObject);
                CreateNewBall();
            }
        }

        private void CreateNewBall()
        {
            var randomVector = new Vector3(Random.Range(0.1f, 0.4f), 0, Random.Range(0.5f, 0.8f));
            randomVector = Random.value > 0.5 ? randomVector : -randomVector;
            ballFactory.Create(randomVector);
        }
    }
}
