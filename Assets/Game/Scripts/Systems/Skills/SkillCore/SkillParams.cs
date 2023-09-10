using System;
using System.Collections.Generic;
using Game.Scripts.Systems.Data;

namespace Game.Scripts.Systems.Skills.SkillCore
{
    [Serializable]
    public class SkillParams
    {
        public List<BattleEntity> user;
        public List<BattleEntity> target;
    }
}