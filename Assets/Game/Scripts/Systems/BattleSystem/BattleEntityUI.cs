using Game.Scripts.Core;
using Game.Scripts.Systems.Data;
using Michsky.MUIP;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.BattleSystem
{
    public class BattleEntityUI : MonoBehaviour, ISaveable
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private ProgressBar healthBar;
        [SerializeField] private ProgressBar techPointsBar;
        
        public BattleEntity battleEntity;

        private void Start()
        {
            UpdateName();
        }

        private void Update()
        {
            healthBar.maxValue = battleEntity.stats.maxHealth;
            healthBar.ChangeValue(battleEntity.stats.health);
            
            techPointsBar.maxValue = battleEntity.stats.maxTechPoints;
            techPointsBar.ChangeValue(battleEntity.stats.techPoints);
        }

        public void UpdateName()
        {
            nameText.text = battleEntity.name;
        }

        public object CaptureState()
        {
            throw new System.NotImplementedException();
        }

        public void RestoreState(object state)
        {
            throw new System.NotImplementedException();
        }
        
        public class Factory : PlaceholderFactory<BattleEntity, BattleEntityUI> { }
    }
}