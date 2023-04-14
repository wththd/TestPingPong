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
        
        public override void InstallBindings()
        {
            Container.BindInstance(elementsContainer);
        }
    }
}