using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Game.Scripts.Systems.Skills.SkillCore;
using Game.Scripts.Systems.Skills.SkillEffects;
using Game.Scripts.Systems.Skills.SkillScripts;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class SkillInstaller : MonoInstaller
    {
        private const string SKILL_PATH = "ScriptableObjects/Skills/";
        public override void InstallBindings()
        {
            Container.BindFactory<string, SkillParams, Skill, Skill.Factory>().FromFactory<SkillFactory>();
        }
    }
}