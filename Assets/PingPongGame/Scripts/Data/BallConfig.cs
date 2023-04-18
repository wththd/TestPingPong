using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace PingPongGame.Scripts.Data
{
    [Serializable]
    [DataContract]
    public class BallConfig
    {
        [DataMember (Name = "ball_color")]
        public BallColor BallColor;
        //[DataMember (Name = "ball_tail")]
        //public Gradient BallTail;
    }
}