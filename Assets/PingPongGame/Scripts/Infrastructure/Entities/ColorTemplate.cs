using System;
using PingPongGame.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    public class ColorTemplate : MonoBehaviour
    {
        public event Action<BallConfig> Clicked;
        
        [SerializeField] 
        private Button button;
        [SerializeField]
        private Image lockedImage;
        [SerializeField] 
        private Image selected;

        [HideInInspector]
        public BallConfig config;
        
        
        [Inject]
        private void Init(BallConfig config, bool unlocked, Transform parent)
        {
            button.image.color = config.BallColor.Color;
            button.interactable = unlocked;
            lockedImage.gameObject.SetActive(!unlocked);
            transform.SetParent(parent, false);
            this.config = config;
        }

        public void SetSelectionState(bool state)
        {
            selected.gameObject.SetActive(state);
        }

        public void OnButtonClick()
        {
            Clicked?.Invoke(config);
        }
    }
}