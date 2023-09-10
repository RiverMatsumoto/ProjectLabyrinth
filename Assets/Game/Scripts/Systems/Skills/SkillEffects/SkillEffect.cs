using System;
using Game.Scripts.Systems.Skills.SkillCore;
using Zenject;

namespace Game.Scripts.Systems.Skills.SkillEffects
{
    [Serializable]
    public abstract class SkillEffect
    {
        public abstract void Execute();
        public class Factory : PlaceholderFactory<string, SkillParams, SkillEffect> { }
    }
}