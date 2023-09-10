using System.Collections.Generic;
using Game.Scripts.Systems.Data;
using Game.Scripts.Systems.Skills.SkillCore;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.BattleSystem
{
    public class BattleSystem : MonoBehaviour
    {
        [Inject]
        private Skill.Factory _skillFactory;
        
        public void StartBattle()
        {
            // Initialize all battle things, move player, add battle scene
        }

        [Button]
        public void GetAttackSkill()
        {
            SkillData sd = Skill.GetSkillData("Attack");
            
            SkillParams sp = new SkillParams
            {
                user = new List<BattleEntity> {},
                target = new List<BattleEntity> {null},
            };
            Skill skill = _skillFactory.Create(sd.name, sp);
            skill.Execute();
        }
    }
}
