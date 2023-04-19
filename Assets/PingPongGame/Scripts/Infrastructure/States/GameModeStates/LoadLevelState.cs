using PingPongGame.Scripts.Data;
using PingPongGame.Scripts.Infrastructure.Factories;
using PingPongGame.Scripts.Infrastructure.SaveSystem;
using PingPongGame.Scripts.Infrastructure.StateIntents;
using PingPongGame.Scripts.Infrastructure.StateMachine;
using PingPongGame.Scripts.Infrastructure.UIElements;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.States.GameModeStates
{
    public class LoadLevelState : State<LoadLevelStateIntent>
    {
        private GameModeStateMachine gameModeStateMachine;
        private BallFactory ballFactory;
        private BoardFactory boardFactory;
        private PlayerRocketFactory playerRocketFactory;
        private IGameStateSaver gameStateSaver;
        private GeneralConfig generalConfig;
        private SharedGameData sharedGameData;
        private AIRocketFactory aiRocketFactory;
        
        public LoadLevelState(GameModeStateMachine gameModeStateMachine, GameModeStateProvider gameModeStatesProvider,
            BallFactory ballFactory, BoardFactory boardFactory, PlayerRocketFactory playerRocketFactory, IGameStateSaver gameStateSaver, GeneralConfig generalConfig,
            SharedGameData sharedGameData, AIRocketFactory aiRocketFactory)
        {
            gameModeStatesProvider.RegisterState(this);

            this.gameModeStateMachine = gameModeStateMachine;
            this.ballFactory = ballFactory;
            this.boardFactory = boardFactory;
            this.playerRocketFactory = playerRocketFactory;
            this.gameStateSaver = gameStateSaver;
            this.generalConfig = generalConfig;
            this.sharedGameData = sharedGameData;
            this.aiRocketFactory = aiRocketFactory;
        }
        
        public override void EnterState()
        {
            DisposeCurrentEntities();
            var board = boardFactory.Create(new BoardFactory.Settings
            {
                PlaneScale = GetPlaneScale()
            });
            sharedGameData.Board = board;
            var randomVector = new Vector3(Random.Range(0.1f, 0.4f), 0, Random.Range(0.5f, 0.8f));
            randomVector = Random.value > 0.5 ? randomVector : -randomVector;
            var ball = ballFactory.Create(new BallFactory.Settings
            {
                Direction = randomVector,
                BallConfig = gameStateSaver.CurrentConfig.BallConfig,
                HitForce = generalConfig.HitForce,
                SmoothingFactor = generalConfig.SmoothingFactor,
                TargetSpeed = generalConfig.TargetSpeed,
                SavedData = gameStateSaver.CurrentConfig.CurrentGameProgress?.BallData
            }, board.BallSpawnPosition);
            sharedGameData.Ball = ball;

            var scale = new Vector3(generalConfig.RocketLength * 10, 1, 0.2f);
            var borders = new Vector2(board.LeftWallTransform.position.x, board.RightWallTransform.position.x);
            var playerRocket = playerRocketFactory.Create(new PlayerRocketFactory.Settings
            {
                Parent = board.PlayerRocketSpawnPosition,
                Speed = generalConfig.RocketSpeed,
                WallPositions = borders,
                Scale = scale,
                IsPlayer = true,
                SavedData = gameStateSaver.CurrentConfig.CurrentGameProgress?.PlayerRocketData
            });
            sharedGameData.PlayerRocket = playerRocket;

            if (Intent.GameMode == GameModeScreen.GameMode.Single)
            {
                var enemyRocket = playerRocketFactory.Create(new PlayerRocketFactory.Settings
                {
                    Parent = board.OppositeRocketSpawnPosition,
                    Speed = generalConfig.RocketSpeed,
                    WallPositions = borders,
                    Scale = scale,
                    IsPlayer = false,
                    SavedData = gameStateSaver.CurrentConfig.CurrentGameProgress?.OppositeRocketData
                });
                sharedGameData.OppositeRocket = enemyRocket;
            } else if (Intent.GameMode == GameModeScreen.GameMode.AI)
            {
                var enemyRocket = aiRocketFactory.Create(new AIRocketFactory.Settings
                {
                    Parent = board.OppositeRocketSpawnPosition,
                    Speed = generalConfig.RocketSpeed,
                    WallPositions = borders,
                    Scale = scale,
                    SavedData = gameStateSaver.CurrentConfig.CurrentGameProgress?.OppositeRocketData,
                    MoveReaction = generalConfig.AIReactionDistance
                });
                sharedGameData.OppositeRocket = enemyRocket;
            }
            
            gameModeStateMachine.SetState<CountdownState>();
        }

        public override void ExitState()
        {
        }

        private void DisposeCurrentEntities()
        {
            if (sharedGameData.Board != null)
            {
                sharedGameData.Board.Dispose();
                sharedGameData.Board = null;
            }

            if (sharedGameData.Ball != null)
            {
                sharedGameData.Ball.Dispose();
                sharedGameData.Ball = null;
            }

            if (sharedGameData.PlayerRocket != null)
            {
                sharedGameData.PlayerRocket.Dispose();
                sharedGameData.PlayerRocket = null;
            }

            if (sharedGameData.OppositeRocket != null)
            {
                sharedGameData.OppositeRocket.Dispose();
                sharedGameData.OppositeRocket = null;
            }
        }

        private Vector2 GetPlaneScale()
        {
            return Camera.main.aspect == 0.5f ? new Vector2(0.9f, 1.8f) : new Vector2(0.9f, 1.6f);
        }
    }
}