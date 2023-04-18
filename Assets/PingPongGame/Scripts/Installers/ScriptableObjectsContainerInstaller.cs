using PingPongGame.Scripts.Data;
using UnityEngine;
using Zenject;

namespace PingPongGame.Scripts.Installers
{
    [CreateAssetMenu(fileName = "ScriptableObjectsContainerInstaller", menuName = "Installers/ScriptableObjectsContainerInstaller")]
    public class ScriptableObjectsContainerInstaller : ScriptableObjectInstaller<ScriptableObjectsContainerInstaller>
    {
        [SerializeField]
        private UIElementsContainer elementsContainer;
        [SerializeField] 
        private GeneralConfig generalConfig;
        [SerializeField]
        private SinglePlayerLevelConfigsContainer singlePlayerLevelConfigsContainer;
        [SerializeField] 
        private MultiPlayerLevelConfigsContainer multiPlayerLevelConfigsContainer;
        
        public override void InstallBindings()
        {
            Container.BindInstance(elementsContainer);
            Container.BindInstance(generalConfig);
            Container.BindInstance(singlePlayerLevelConfigsContainer);
            Container.BindInstance(multiPlayerLevelConfigsContainer);
        }
    }
}