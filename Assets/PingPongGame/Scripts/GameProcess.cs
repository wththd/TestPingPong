using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts
{
    public class GameProcess : MonoBehaviour
    {
        private BallFactory ballFactory;
    
        [Inject]
        private void Init(BallFactory ballFactory)
        {
            this.ballFactory = ballFactory;
        }
    
        // Start is called before the first frame update
        void Start()
        {
            CreateNewBall();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        private void CreateNewBall()
        {
            var randomVector = new Vector3(Random.Range(0.1f, 0.4f), 0, Random.Range(0.5f, 0.8f));
            randomVector = Random.value > 0.5 ? randomVector : -randomVector;
            ballFactory.Create(randomVector);
        }
    }
}
