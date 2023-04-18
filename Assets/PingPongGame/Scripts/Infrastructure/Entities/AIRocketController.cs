
using System;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.Entities
{
    public class AIRocketController
    {
        public bool ShouldMove => Math.Abs(Position.position.x - Target.position.x) > MoveDifference;
        public Transform Target { get; set; }
        public Transform Position { get; set; }
        public float MoveDifference { get; set; }
    }
}