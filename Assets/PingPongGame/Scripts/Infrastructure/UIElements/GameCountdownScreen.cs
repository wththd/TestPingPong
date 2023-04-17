using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.UIElements
{
    public class GameCountdownScreen : MonoBehaviour
    {
        public event Action CountdownFinished;
        [SerializeField]
        private TextMeshProUGUI countdownText;

        public void StartCountDown(float time)
        {
            countdownText.text = time.ToString("0");
            StartCoroutine(CountdownRoutine(time));
        }

        private IEnumerator CountdownRoutine(float time)
        {
            var passedTime = 0f;
            while (time > 0)
            {
                while (passedTime <= 1)
                {
                    passedTime += Time.deltaTime;
                    yield return null;
                }

                passedTime -= 1;
                time -= 1;
                countdownText.text = time.ToString("0");
            }
            
            CountdownFinished?.Invoke();
        }

        public void Close()
        {
            if (gameObject != null){
                Destroy(gameObject);
            }
        }
    }
}