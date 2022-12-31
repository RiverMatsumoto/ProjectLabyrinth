using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Scripts.Installers
{
    public class MainMenuInstaller : MonoInstaller<MainMenuInstaller>
    {
        [SerializeField] private PlayerInput _input;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerInput>().FromInstance(_input).AsSingle();
        }
    }
}
