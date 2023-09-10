using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.Skills.SkillCore
{
    /// <summary>
    /// Creates instances of skills based on their name.
    /// </summary>
    public class SkillFactory : IFactory<string, SkillParams, Skill>
    {
        readonly Assembly assembly  = Assembly.GetExecutingAssembly();
        private readonly DiContainer _container;
        private readonly Type[] _derivedTypes;
        private readonly Dictionary<string, Type> _types;
        
        public SkillFactory(DiContainer container)
        {
            _container = container;
            _derivedTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Skill))).ToArray();
            _types = new Dictionary<string, Type>();
            foreach (Type type in _derivedTypes)
            {
                _types.Add(type.Name, type);
            }
        }
    
        public Skill Create(string skillName, SkillParams skillParams)
        {
            skillName += "Skill";
            if (_types.ContainsKey(skillName))
            {
                return (Skill)_container.Instantiate(_types[skillName], new object[] { skillParams });
            }
            return null;
        }
    }
}