using Game.UI.OtherUI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private GameObject showFPS;
        
        public override void InstallBindings()
        {
            
            // Container.Bind<Canvas>().FromComponentInNewPrefab(canvas).AsSingle().NonLazy();
            Container.Bind<ShowFPS>().FromComponentInNewPrefab(showFPS).AsSingle().NonLazy();
        }

        private void AddUIToCanvas()
        {
            // showFPS.transform.parent = canvas.transform;
        }
    }
}