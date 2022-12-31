using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.SkillCommands;
using Game.Scripts.Systems.SkillCommands.Factories;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class SkillCommandInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // create the skill commands for future use
            // Container.Bind<int>().FromInstance(100).AsSingle().WhenInjectedInto<StaticHealCommand>();
            // Container.Bind<string>().FromInstance("RIVER").AsSingle().WhenInjectedInto<StaticHealCommand>();
            Container.Bind<SkillCommandProvider>().AsSingle();
            Container.BindFactory<string, int, StaticHealCommand, StaticHealCommand.Factory>().AsSingle().NonLazy();
            Container.BindFactory<float, int, EncounterMultiplier, EncounterMultiplier.Factory>()
                .AsSingle().NonLazy();
            Container.BindFactory<AttackCommand, AttackCommand.Factory>().AsSingle().NonLazy();
            Container.BindFactory<BoxCollider, EnableDialogueCommand, EnableDialogueCommand.Factory>().AsSingle()
                .NonLazy();
        }
    }
}