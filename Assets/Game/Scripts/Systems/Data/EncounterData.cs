using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Systems.Data
{
    [CreateAssetMenu(menuName = "GameData/EncounterData", fileName = "EncounterData")]
    public class EncounterData : SerializedScriptableObject
    {
        public float encounterMultiplier = 1f;
    }
}
