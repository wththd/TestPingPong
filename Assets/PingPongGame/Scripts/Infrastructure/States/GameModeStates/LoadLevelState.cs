using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.States.GameModeStates
{
    public class LoadLevelState : State<EmptyStateIntent>
    {
        private GameModeStateMachine gameModeStateMachine;
        private BallFactory ballFactory;
        private BoardFactory boardFactory;
        private PlayerRocketFactory playerRocketFactory;
        
        public LoadLevelState(GameModeStateMachine gameModeStateMachine, GameModeStateProvider gameModeStatesProvider,
            BallFactory ballFactory, BoardFactory boardFactory, PlayerRocketFactory playerRocketFactory)
        {
            gameModeStatesProvider.RegisterState(this);

            this.gameModeStateMachine = gameModeStateMachine;
            this.ballFactory = ballFactory;
            this.boardFactory = boardFactory;
            this.playerRocketFactory = playerRocketFactory;
        }
        
        public override void EnterState()
        {
            var board = boardFactory.Create(new BoardFactory.Settings());
            var randomVector = new Vector3(Random.Range(0.1f, 0.4f), 0, Random.Range(0.5f, 0.8f));
            randomVector = Random.value > 0.5 ? randomVector : -randomVector;
            var ball = ballFactory.Create(new BallFactory.Settings
            {
                Direction = randomVector
            }, board.BallSpawnPosition);

            var playerRocket = playerRocketFactory.Create(new PlayerRocketFactory.Settings
            {
                Parent = board.PlayerRocketSpawnPosition,
                Speed = 25,
                WallPositions = new Vector2(board.LeftWallTransform.position.x, board.RightWallTransform.position.x)
            });
            
            gameModeStateMachine.SetState<CountdownState>();
        }

        public override void ExitState()
        {
        }
    }
}