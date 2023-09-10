using System;
using System.Collections.Generic;
using Game.Scripts.Systems.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Systems.Skills.SkillCore
{
    [CreateAssetMenu(fileName = "New Skill Data", menuName = "GameData/Skills/Skill Data")]
    public class SkillData : SerializedScriptableObject
    {
        public new string name;
        [TextArea]
        public string description;
        public float speed;

        public TargettingBehavior targettingBehavior;
        public TargetType targetType;
        public bool reactiveSkill;
        public Func<bool> isInterested;
        public Action onReact;
        public bool persistentThroughRounds;
        
    }
}