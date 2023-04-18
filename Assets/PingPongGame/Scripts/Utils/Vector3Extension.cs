using System.Numerics;

namespace PingPongGame.Scripts.Utils
{
    public static class Vector3Extension
    {
        public static Vector3 ToNumeric(this UnityEngine.Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, vector.z);
        }
        
        public static UnityEngine.Vector3 ToUnityEngineVector(this Vector3 vector)
        {
            return new UnityEngine.Vector3(vector.X, vector.Y, vector.Z);
        }
    }
}