using System.Collections.Generic;
using Game.Scripts.Systems.SkillCommands;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Systems.Data.Items.ItemCore
{
    [CreateAssetMenu(menuName = "GameData/Item", fileName = "New Item")]
    public class ItemObject : SerializedScriptableObject
    {
        [BoxGroup("Item Data")]
        public new readonly string name;
        [BoxGroup("Item Data"), TextArea]
        public readonly string description;
        [BoxGroup("Item Data")]
        public Sprite sprite;
        [BoxGroup("Item Data")]
        public GameObject gameObject;

        public readonly bool usableInField;
        public readonly bool usableInBattle;

        
    }
}
