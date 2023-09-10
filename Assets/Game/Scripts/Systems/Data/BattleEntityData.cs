using System.Collections.Generic;
using System.Security.Cryptography;
using Game.Scripts.Systems.Skills.SkillCore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Systems.Data
{
    [CreateAssetMenu(menuName = "GameData/CharacterData", fileName = "New Character Data")]
    public class BattleEntityData : ScriptableObject
    {
        public new string name;
        public string description;
        // TODO Sprite
        [OnValueChanged("IsEnemyUpdateData"), OnInspectorInit("IsEnemyUpdateData")]
        public bool isEnemy;
        [HorizontalGroup("Resistances/Lists", Width = 0.5F), BoxGroup("Resistances"), PropertyOrder(4), DictionaryDrawerSettings(KeyLabel = "Effect", ValueLabel = "%", KeyColumnWidth = 50), PropertySpace]
        public Dictionary<StatusEffect, int> statusEffectResistance;
        [ProgressBar(0,100, ColorGetter = "@Color.white"), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int levelBar;
        [ProgressBar(0,"$MAX_HP", 1F,0.2F,0.1F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int maxHealthBar;
        [ProgressBar(0,999, 0.2F,0.3F,0.9F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int maxTechPointsBar;
        [ProgressBar(0,300, 0.85F,0.15F,0.1F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int strengthBar; //, vitality, wisdom, agility, tech, luck;
        [ProgressBar(0,300, 0.5F,0.5F,1), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int intelligenceBar;
        [ProgressBar(0,300, 1F,0.5F,0F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int vitalityBar;
        [ProgressBar(0,300, 0.5F,0.1F,1), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int wisdomBar;
        [ProgressBar(0,300, 0.9F,0.2F,0.9F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int agilityBar;
        [ProgressBar(0,300, 0,0.9F,0), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
        public int luckBar;
    
        [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Level"), PropertyOrder(1)]
        public int level;
        [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Max HP"), PropertyOrder(1)]
        public int maxHealth;
        [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Max TP"), PropertyOrder(1)]
        public int maxTechPoints;
        [SerializeField, OnValueChanged("CopyToStats"), HorizontalGroup("Stats/Split", Width = 40, Order = 0, LabelWidth = 60), VerticalGroup("Stats/Split/Left"), PropertyOrder(1), LabelText("Strength"), TitleGroup("Stats")]
        public int strength;
        [SerializeField, OnValueChanged("CopyToStats"), HorizontalGroup("Stats/Split", Width = 40, Order = 0, LabelWidth = 60), VerticalGroup("Stats/Split/Left"), PropertyOrder(1), LabelText("Intelligence"), TitleGroup("Stats")]
        public int intelligence;
        [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Vitality"), PropertyOrder(1)]
        public int vitality;
        [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Wisdom"), PropertyOrder(1)]
        public int wisdom;
        [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Agility"), PropertyOrder(1)]
        public int agility;
        [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Luck"), PropertyOrder(1), PropertySpace(SpaceBefore = 0, SpaceAfter = 10)]
        public int luck;
        private int MAX_HP;

        public List<string> knownSkills;

        public Stats ToStats()
        {
            return new Stats(level, maxHealth, maxTechPoints, strength, intelligence, vitality, wisdom, agility,
                luck);
        }

        private void IsEnemyUpdateData()
        {
            MAX_HP = isEnemy ? 100_000 : 999;
        }

        private void CopyToStats()
        {
            levelBar = level;
            maxHealthBar = maxHealth;
            maxTechPointsBar = maxTechPoints; 
            strengthBar = strength;
            intelligenceBar = intelligence;
            vitalityBar = vitality;
            wisdomBar = wisdom;
            agilityBar = agility;
            luckBar = luck;
        }

        private void CopyFromStats()
        {
            level = levelBar;
            maxHealth = maxHealthBar;
            maxTechPoints = maxTechPointsBar;
            strength = strengthBar;
            intelligence = intelligenceBar;
            vitality = vitalityBar;
            wisdom = wisdomBar;
            agility = agilityBar;
            luck = luckBar;
        }
    }
}