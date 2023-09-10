using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.Commands.Factories;
using Game.Scripts.Systems.Data;
using Game.Scripts.Systems.SkillCommands;
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
            Container.BindFactory<string, int, StaticHealCommand, StaticHealCommand.Factory>().AsSingle();
            Container.BindFactory<float, int, EncounterMultiplier, EncounterMultiplier.Factory>()
                .AsSingle();
            Container.BindFactory<BattleEntity, BattleEntity, AttackCommand, AttackCommand.Factory>().AsSingle();
            Container.BindFactory<BoxCollider, EnableDialogueCommand, EnableDialogueCommand.Factory>().AsSingle();
        }
    }
}