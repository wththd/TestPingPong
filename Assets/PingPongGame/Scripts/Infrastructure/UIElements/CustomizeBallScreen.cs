using System;
using System.Collections.Generic;
using System.Linq;
using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Entities;
using PingPongGame.Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.UIElements
{
    public class CustomizeBallScreen : MonoBehaviour
    {
        public event Action Closed;
        public event Action Applied;

        public BallConfig BallConfig => ballConfig;

        [SerializeField] 
        private Transform content;
        private BallConfig ballConfig;
        private ColorTemplateFactory colorTemplateFactory;
        private List<ColorTemplate> currentTemplates = new();

        [Inject]
        private void Init(ColorTemplateFactory colorTemplateFactory)
        {
            this.colorTemplateFactory = colorTemplateFactory;
        }

        public void Populate(Dictionary<BallConfig, bool> allConfigs, BallConfig currentConfig)
        {
            foreach (var config in allConfigs)
            {
                var template = colorTemplateFactory.Create(config.Key, config.Value, content);
                template.Clicked += TemplateOnClicked;
                currentTemplates.Add(template);
            }

            SelectBallConfig(currentConfig);
        }

        private void TemplateOnClicked(BallConfig config)
        {
            SelectBallConfig(config);
        }

        private void SelectBallConfig(BallConfig config)
        {
            DeselectAll();
            var template = currentTemplates.First(template => Equals(template.config, config));
            template.SetSelectionState(true);
            ballConfig = config;
        }

        private void DeselectAll()
        {
            foreach (var template in currentTemplates)
            {
                template.SetSelectionState(false);
            }
        }

        public void OnCloseClick()
        {
            Closed?.Invoke();
        }

        public void OnApplyClick()
        {
            Applied?.Invoke();
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}