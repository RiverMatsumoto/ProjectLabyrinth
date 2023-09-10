using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.BattleSystem
{
    public class BattleEntityPartyUI : MonoBehaviour
    {
        [Inject] private BattleEntityUI.Factory _battleEntityUIFactory;
        [SerializeField] private GameObject frontRow;
        [SerializeField] private GameObject backRow;
        

        public void InstantiateParty()
        {
            
        }
    }
}