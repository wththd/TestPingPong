using System.Collections.Generic;
using System.Runtime.Serialization;
using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Data
{
    [DataContract]
    public class GameConfig
    {
        [DataMember(Name = "current_ball_config")]
        public BallConfig BallConfig;
        [DataMember(Name = "current_game_mode")]
        public GameModeScreen.GameMode CurrentGameMode;
        [DataMember(Name = "current_game_progress")]
        public CurrentGameProgress CurrentGameProgress = new();
        [DataMember(Name = "current_single_player_progress")]
        public CurrentPlayerProgress CurrentPlayerSingleProgress = new();
        [DataMember(Name = "current_multi_player_progress")]
        public CurrentPlayerProgress CurrentPlayerMultiplayerProgress = new();
        [DataMember(Name = "current_opened_ball_configs")]
        public List<BallConfig> Rewards = new();

        public bool HasProgress => CurrentGameProgress is { BallData: not null, OppositeRocketData: not null, PlayerRocketData: not null };

        public void ClearCurrentGameProgress()
        {
            CurrentGameProgress = new CurrentGameProgress();
        }
    }
}