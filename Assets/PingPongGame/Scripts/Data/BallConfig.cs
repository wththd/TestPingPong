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
        
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            var c = (BallConfig) obj;
            return Equals(BallColor.Color, c.BallColor.Color);
        }
    }
}