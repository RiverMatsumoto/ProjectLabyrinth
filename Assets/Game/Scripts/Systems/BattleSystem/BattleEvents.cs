using Game.Scripts.Systems.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Systems.BattleSystem
{
    [CreateAssetMenu(fileName = "BattleEvents", menuName = "GameData/BattleEvents")]
    public class BattleEvents : ScriptableObject
    {
        public UnityEvent onBattleStart;
        public UnityEvent onPlayerDied;
        
        public UnityEvent onPreAttack;
    }
}