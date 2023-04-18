using System.Numerics;
using System.Runtime.Serialization;

namespace PingPongGame.Scripts.Data
{
    [DataContract]
    public class BallData
    {
        [DataMember(Name = "position")]
        public Vector3 Position;
        [DataMember(Name = "speed")]
        public Vector3 Speed;
    }
}