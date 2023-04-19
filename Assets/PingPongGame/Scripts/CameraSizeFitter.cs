using System;
using UnityEngine;

namespace PingPongGame.Scripts
{
    [RequireComponent(typeof(Camera))]
    public class CameraSizeFitter : MonoBehaviour
    {
        private void Awake()
        {
            var camera = GetComponent<Camera>();
            switch (camera.aspect)
            {
                // Set size for 9-18 device
                case 0.5f:
                    camera.orthographicSize = 9;
                    break;
                default:
                    camera.orthographicSize = 8;
                    break;
            }
        }
    }
}