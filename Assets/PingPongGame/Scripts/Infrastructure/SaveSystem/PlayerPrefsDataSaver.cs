using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PingPongGame.Scripts.Data;
using UnityEngine;

namespace PingPongGame.Scripts.Infrastructure.SaveSystem
{
    public class PlayerPrefsDataSaver : IDataSaver<GameConfig>
    {
        private const string StoragePrefsKey = "config_data";

        public void Save(GameConfig gameConfig)
        {
            try
            {
                var json = JsonConvert.SerializeObject(gameConfig);
                PlayerPrefs.SetString(StoragePrefsKey, json);
                PlayerPrefs.Save();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        public Task<GameConfig> Load()
        {
            var config = new GameConfig();
            if (PlayerPrefs.HasKey(StoragePrefsKey))
            {
                config = JsonConvert.DeserializeObject<GameConfig>(PlayerPrefs.GetString(StoragePrefsKey));
            }

            return Task.FromResult(config);
        }
    }
}