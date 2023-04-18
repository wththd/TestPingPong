using PingPongGame.Scripts.Data;

namespace PingPongGame.Scripts.Infrastructure.SaveSystem
{
    public interface ISavable
    {
        void Save(GameConfig gameConfig);
    }
}