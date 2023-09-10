using System.Collections.Generic;
using Game.Scripts.Systems.Commands;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.Skills.SkillCore
{
    public abstract class Skill : ICommand
    {
        public SkillParams skillParams { get; protected set; }

        public Skill(SkillParams skillParams) => this.skillParams = skillParams;
        
        public abstract void Execute();

        [Button]
        public static SkillData GetSkillData(string skillName) => 
            Resources.Load<SkillData>("ScriptableObjects/Skills/" + skillName);

        public class Factory : PlaceholderFactory<string, SkillParams, Skill> { }

    }
}