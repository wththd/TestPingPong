using System;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.PauseSystem;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Utils;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour, IPausable, ISavable
    { 
        public event Action HitRocket;
        
        private Rigidbody rb;

        private Vector3 startDirection;
        private float targetSpeed;
        private float smoothingFactor;
        private float hitForce;
        private BallConfig ballConfig;
        private Vector3? savedSpeed;

        private bool isPaused;
        private Vector3 pausedSpeed;
        private BallData saveData = new();
        private IPauseHandler pauseHandler;
        private IGameStateSaver gameStateSaver;
        private Material currentMaterial;

        [Inject]
        private void Init(BallFactory.Settings settings, Transform rootTransform, IPauseHandler pauseHandler, IGameStateSaver gameStateSaver)
        {
            isPaused = pauseHandler.RegisterPausable(this);
            gameStateSaver.RegisterSavable(this);

            this.pauseHandler = pauseHandler;
            this.gameStateSaver = gameStateSaver;

            ballConfig = settings.BallConfig;
            startDirection = settings.Direction;
            targetSpeed = settings.TargetSpeed;
            smoothingFactor = settings.SmoothingFactor;
            hitForce = settings.HitForce;
            transform.SetParent(rootTransform, false);
            if (settings.SavedData != null)
            {
                transform.position = settings.SavedData.Position.ToUnityEngineVector();
                savedSpeed = settings.SavedData.Speed.ToUnityEngineVector();
            }
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            pausedSpeed = savedSpeed ?? startDirection * targetSpeed;
            
            currentMaterial = GetComponent<Renderer>().material;
            currentMaterial.color = ballConfig.BallColor.Color;
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
            saveData.Position = transform.localPosition.ToNumeric();
            saveData.Speed = rb.velocity.ToNumeric();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Rocket"))
            {
                var rocketSpeed = other.gameObject.GetComponent<Rocket>().RelativeSpeed;
                if (rocketSpeed > 1)
                {
                    rb.AddForce(hitForce * rocketSpeed * rb.velocity.normalized, ForceMode.Impulse);
                }
                
                currentMaterial.SetVector("_ContactPoint", other.GetContact(0).point);
                currentMaterial.SetFloat("_Contact", 1);
                
                HitRocket?.Invoke();
            }
        }

        private void OnDestroy()
        {
            pauseHandler.UnregisterPausable(this);
            gameStateSaver.UnregisterSavable(this);
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

        public void Save(GameConfig gameConfig)
        {
            gameConfig.CurrentGameProgress.BallData = saveData;
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}