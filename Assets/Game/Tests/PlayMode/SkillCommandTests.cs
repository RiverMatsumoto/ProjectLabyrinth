using System.Collections;
using Game.Scripts.Core;
using Game.Scripts.Movement;
using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.MapSystem;
using Game.Scripts.Systems.Movement;
using Game.Scripts.Systems.SkillCommands;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;
using Zenject;
using Zenject.SpaceFighter;

namespace Game.Tests.PlayMode
{
    public class SkillCommandTests : ZenjectIntegrationTestFixture
    {
        public void CommonInstall()
        {
            PreInstall();
            
            Container.Bind<GameData>().FromScriptableObjectResource("ScriptableObjects/GameData").AsSingle();
            Container.Bind<MapSystem>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<PlayerMovement>().FromNewComponentOnNewGameObject().AsSingle();
            PlayerMovement playerMovement = Container.Resolve<PlayerMovement>();
            // playerMovement.GetComponent<PlayerInput>().SwitchCurrentActionMap();
            Container.Bind<EncounterSystem>().FromNewComponentOnNewGameObject().AsSingle();
            
            PostInstall();
        }
        
        [Inject] private EncounterSystem _encounterSystem;
        
        [UnityTest]
        public IEnumerator EnableDialogueCommandTest()
        {
            CommonInstall();
            
            GameObject dialogueDummy = new GameObject();
            dialogueDummy.AddComponent<BoxCollider>();
            BoxCollider dialogueTrigger = dialogueDummy.GetComponent<BoxCollider>();
            dialogueTrigger.enabled = false;
            
            Assert.AreEqual(false, dialogueTrigger.enabled);
            
            ISkillCommand enableDialogueCommand = new EnableDialogueCommand(dialogueTrigger);
            enableDialogueCommand.Execute();

            Assert.AreEqual(true, dialogueTrigger.enabled);
            yield break;
        }

        [UnityTest]
        public IEnumerator EncounterMultiplierTest()
        {
            CommonInstall();
            
            Assert.AreEqual(1f, _encounterSystem.dangerMultiplier);

            ISkillCommand encounterMultiplier = new EncounterMultiplier(_encounterSystem, 2f, 20);
            encounterMultiplier.Execute();
            
            Assert.AreEqual(2f, _encounterSystem.dangerMultiplier);
            yield break;
        }
    }
}