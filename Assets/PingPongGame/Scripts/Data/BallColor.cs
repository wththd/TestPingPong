using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine;

namespace PingPongGame.Scripts.Data
{
    [DataContract]
    [Serializable]
    public class BallColor
    {
        [JsonIgnore]
        [SerializeField] private Color color;
        
        [DataMember (Name = "r")]
        private float r;
        [DataMember (Name = "g")]
        private float g;
        [DataMember (Name = "b")]
        private float b;

        public Color Color
        {
            get => new(r, g, b, 1);
            set
            {
                r = value.r;
                g = value.g;
                b = value.b;
            }
        }

        public void OnValidate()
        {
            r = color.r;
            g = color.g;
            b = color.b;
        }
    }
}