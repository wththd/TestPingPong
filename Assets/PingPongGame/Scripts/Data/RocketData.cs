using System.Numerics;
using System.Runtime.Serialization;

namespace PingPongGame.Scripts.Data
{
    [DataContract]
    public class RocketData
    {
        [DataMember(Name = "position")]
        public Vector3 Position;
    }
}