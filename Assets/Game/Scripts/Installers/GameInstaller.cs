using Game.Scripts.Core;
using Game.UI.MainMenu;
using ProjectLabyrinth.Game.UI.PlayerMenu;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
public class GameInstaller : MonoInstaller
{
    [SerializeField] private SettingsData settingsData;
    [SerializeField] private GameData gameData;
    [SerializeField] private PlayerMenu playerMenu;
    [SerializeField] private GameObject _sceneChanger;


    public override void InstallBindings()
    {
        Application.targetFrameRate = 1000;

        Instantiate(_sceneChanger);
        SignalBusInstaller.Install(Container);
        Container.Bind<GameData>().FromInstance(gameData).AsSingle();
        Container.Bind<SettingsData>().FromInstance(settingsData).AsSingle();
        Container.Bind<PlayerMenu>().FromInstance(playerMenu).AsSingle();

        InstallUI();
    }

    private void InstallUI()
    {
        Container.BindInterfacesTo<ScaleAnimation>().AsSingle();
    }
}
    
}