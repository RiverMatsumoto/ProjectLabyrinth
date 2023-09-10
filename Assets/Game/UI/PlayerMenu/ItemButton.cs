using System;
using Game.Scripts.Systems.Data;
using Game.Scripts.Systems.Data.Inventory;
using Michsky.MUIP;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Game.UI.PlayerMenu
{
    public class ItemButton : MonoBehaviour
    {
        // private IItem _item;
        private Inventory _inventory;

        public void Initialize()
        {
        }

        private void Start()
        {
            GetComponent<ButtonManager>().onClick.AddListener(UseItem);
        }

        private void UseItem()
        {
        }
    }
}
