using System.Threading.Tasks;

namespace PingPongGame.Scripts.Infrastructure.SaveSystem
{
    public interface IDataSaver<T>
    {
        public void Save(T data);
        public Task<T> Load();
    }
}