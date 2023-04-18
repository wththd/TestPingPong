using System.Threading.Tasks;
using PingPongGame.Scripts.Data;

namespace PingPongGame.Scripts.Infrastructure.SaveSystem
{
    public interface IGameStateSaver
    {
        void SaveBallConfig(BallConfig ballConfig);
        void Save();
        void SaveData();
        Task Load();
        void RegisterSavable(ISavable savable);
        void UnregisterSavable(ISavable savable);
        void AddSingleLevelProgress();
        void AddMultiplayerLevelProgress();
        GameConfig CurrentConfig { get; }
    }
}