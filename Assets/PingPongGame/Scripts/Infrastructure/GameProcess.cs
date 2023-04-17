using PingPongGame.Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts
{
    public class GameProcess
    {
        private Board board;
        
        public void SetBoard(Board board)
        {
            this.board = board;
            //board
        }
    }
}
