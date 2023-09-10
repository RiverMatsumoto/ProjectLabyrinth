using Game.Scripts.Systems.Data.Inventory;
using UnityEngine;

namespace Game.Scripts.Systems.Skills.SkillEffects
{
    public class GiveItemEffect : SkillEffect
    {
        public string item; // TODO implement item system
        public Inventory inventory;
        
        public override void Execute()
        {
            // add item to inventory
        }
    }
}