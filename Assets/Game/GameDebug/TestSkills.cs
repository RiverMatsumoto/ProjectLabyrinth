using Game.Scripts.Systems.Skills.SkillCore;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.GameDebug
{
    public class TestSkills : MonoBehaviour
    {
        [Inject] public Skill.Factory skillFactory;
        
        [Button]
        public void UseSkill()
        {
            SkillData data = Skill.GetSkillData("Attack");
            
            SkillParams skillParams = new SkillParams();
            Skill skill = skillFactory.Create("Attack", skillParams);
            skill.Execute();
        }
    }
}
