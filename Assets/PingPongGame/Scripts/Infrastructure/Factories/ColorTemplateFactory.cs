using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Entities;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Infrastructure.Factories
{
    public class ColorTemplateFactory : PlaceholderFactory<BallConfig, bool, Transform, ColorTemplate>
    {
        
    }
}