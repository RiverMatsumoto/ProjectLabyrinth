using Game.Scripts.Systems.BattleSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.SkillCommands
{
    public class TempTestFactories : MonoBehaviour
    {
        // [Inject] private SkillCommandProvider skillCommands;
        // [Inject, ShowInInspector] private EncounterSystem _encounterSystem;
        // [Button]
        // public void GetStaticHeal(string target, int amount)
        // {
        //     StaticHealCommand heal = skillCommands.CreateStaticHeal(target, amount);
        //     heal.Execute();
        //     // UnityEngine.Debug.Log($"Heal: {heal.Execute()}"); 
        // }
        //
        // [Button]
        // public void GetEncounterMultiplier(float multiplier, int maxSteps)
        // {
        //     skillCommands.CreateEncounterMultiplier(multiplier, maxSteps).Execute();
        // }
    }
}
