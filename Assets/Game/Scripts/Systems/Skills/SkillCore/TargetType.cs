using UnityEditor;
using UnityEngine;

namespace Game.Scripts.Systems.Skills.SkillCore
{
    /// <summary>
    /// Scriptable Object enums for what types of entities to target. Data for
    /// the BattleSystem to know what skill can target what entities
    /// </summary>
    [CreateAssetMenu(fileName = "TargetType", menuName = "GameData/Skills/TargetType")]
    public class TargetType : ScriptableObject { }
}